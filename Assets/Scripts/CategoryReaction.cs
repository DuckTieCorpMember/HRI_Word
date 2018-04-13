using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryReaction : MonoBehaviour {

	public GameObject correctObject;
	public GameObject wrongObject;
    GameController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void WrongActivation()
	{
        wrongObject.SetActive(true);
		StartCoroutine (Wait (wrongObject));
	}

	public void CorrectActivation()
	{
		correctObject.SetActive (true);
        if (controller.robotsTurn)
        {
            controller.robotScore += 1;
        }
        else
        {
            controller.playerScore += 1;
        }
        StartCoroutine (Wait (correctObject));
	}

	IEnumerator Wait(GameObject o)
	{
		yield return new WaitForSeconds(2);
		o.SetActive (false);
	}
}
