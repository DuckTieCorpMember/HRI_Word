using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WordManipulation : MonoBehaviour {

	[SerializeField] public Word word = new Word("a", "it is a", "letter");
	private bool dragging;

	GameObject buttonObject;
	public GameObject pnael_exp;
    GameObject explanation;
	void Start()
	{
        explanation = GameObject.FindGameObjectWithTag("explanation");
		buttonObject = this.gameObject;
	}

	void Update()
	{
		CheckIfInBounds ();
		if (dragging) {
			Move ();
		}
		if (Input.touchCount == 0) {
			dragging = false;
		}
        if(buttonObject.transform.position.z != 0)
        {
            buttonObject.transform.position = new Vector3(buttonObject.transform.position.x, buttonObject.transform.position.y, 0);
        }
	}

	void Move()
	{
		//is there any touches
		if (Input.touchCount > 0) {
			//go through each touch
			for (int i = 0; i < Input.touchCount; i++) {
				//Is this touch moving
				if (Input.GetTouch (i).phase == TouchPhase.Moved) {
					//Track the touch point
					Vector2 touchPos = Input.GetTouch (i).position;
					//move the texture 
					buttonObject.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (touchPos.x, touchPos.y, 0));
				}
			}
		}
	}
	void CheckIfInBounds()
	{
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos))
				dragging = true;
		}
	}

	void OnTriggerStay2D(Collider2D c)
	{
		if (!dragging && c.tag == "category_quiz"){
			string cat = c.gameObject.GetComponentInChildren<Text> ().text;
			WordArray wa = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordArray>();
			string word = this.gameObject.GetComponentInChildren<Text> ().text;
			string corr = wa.GetCategoryOfWord (word);
			//Debug.Log ("CATEGORY IS " + corr);
			CategoryReaction cr = c.gameObject.GetComponent<CategoryReaction>();
			if (cr != null) {
				if (corr == cat) {
					cr.CorrectActivation ();
					Destroy (this.gameObject);
				} else {
					cr.WrongActivation ();
                    pnael_exp = GameObject.FindGameObjectWithTag("explanation");
                    Color cc = explanation.GetComponent<Image>().color;
                    explanation.GetComponent<Image>().color = new Color(cc.r,cc.g,cc.b, 0.5f);
                    cc = explanation.GetComponentInChildren<Text>().color;
                    explanation.GetComponentInChildren<Text>().color = new Color(cc.r, cc.g, cc.b, 0.75f);
                    pnael_exp.GetComponentInChildren<Text> ().text = wa.GetDescriptionOfWord (word);


					StartCoroutine (Wait ());
					this.gameObject.transform.position = new Vector3 (1000, 1000, 0);
				}
			}
		}
	}

	IEnumerator Wait()
	{

		yield return new WaitForSeconds(2);

        Color cc = explanation.GetComponent<Image>().color;
        explanation.GetComponent<Image>().color = new Color(cc.r, cc.g, cc.b, 0f);
        cc = explanation.GetComponentInChildren<Text>().color;
        explanation.GetComponentInChildren<Text>().color = new Color(cc.r, cc.g, cc.b, 0f);

        Destroy (this.gameObject);
	}
}
