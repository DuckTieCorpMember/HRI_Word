using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryChoice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
//		Button b = gameObject.GetComponent<Button> ();
//		Color c = new Color (0.5f, 0.5f, 0.5f);
//		b.colors.normalColor = c;
		int pickedAmount = 0;
		GameObject[] categories = GameObject.FindGameObjectsWithTag("category_picker");
		foreach (GameObject gm in categories) {
			if (gm.GetComponent<Image> ().color == new Color (0.5f, 0.75f, 0.82f)) {
				pickedAmount++;
			}
		}

		Image m = gameObject.GetComponent<Image>();
		if (m.color == new Color (1f, 1f, 1f) && pickedAmount<3) {
			m.color = new Color (0.5f, 0.75f, 0.82f);
		} else
			m.color = new Color (1f, 1f, 1f);
	}
}
