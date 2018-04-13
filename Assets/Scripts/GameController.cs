using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	GameObject[] categories;
	[SerializeField] public List<string> chosen;
	GameObject startButton;
	GameObject start_canvas;
	GameObject quiz_canvas;

    GameObject scoreCanvas;
    Text robotScoreText;
    Text humanScoreText;
    Text scoreMsg;

    GameObject textScore;

	WordArray wa;

	GameObject[] wordsQuiz;
	GameObject[] wordsQuiz_2;
	GameObject[] categoriesQuiz;
    //List<GameObject> reserve;

    GameObject wordsLayout;
    public GameObject prefab;

    public bool robotsTurn = false;
    public int robotScore = 0;
    public int playerScore = 0;

    bool robotCanMove = false;
    [SerializeField] public bool robotShouldWin=false;

	// Use this for initialization
	void Start () {
        //reserve = new List<GameObject>();

		wa = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordArray>();
		wa.BuildArray ();

        wordsLayout = GameObject.FindGameObjectWithTag("words_layout");
        Instantiate(prefab, wordsLayout.transform);

        scoreCanvas = GameObject.FindGameObjectWithTag("scoreCanvas");
        humanScoreText = GameObject.FindGameObjectWithTag("humanScoreText").GetComponent<Text>();
        robotScoreText = GameObject.FindGameObjectWithTag("robotScoreText").GetComponent<Text>();
        scoreMsg = GameObject.FindGameObjectWithTag("scoreMsg").GetComponent<Text>();

		categories = GameObject.FindGameObjectsWithTag ("category_picker");		
		startButton = GameObject.FindGameObjectWithTag ("start_button");

		start_canvas = GameObject.FindGameObjectWithTag ("start_canvas");

		quiz_canvas = GameObject.FindGameObjectWithTag ("quiz_canvas");

        textScore = GameObject.FindGameObjectWithTag("score_Board");

		wordsQuiz = GameObject.FindGameObjectsWithTag ("word_quiz");
		categoriesQuiz = GameObject.FindGameObjectsWithTag ("category_quiz");

		startButton.SetActive (false);
		start_canvas.SetActive (true);
		quiz_canvas.SetActive (false);
        scoreCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (start_canvas.activeSelf)
        {
            int clickedAmount = 0;
            if(robotsTurn)
            {
                categories[0].GetComponent<Image>().color = new Color(0.5f, 0.75f, 0.82f);
                categories[1].GetComponent<Image>().color = new Color(0.5f, 0.75f, 0.82f);
                categories[2].GetComponent<Image>().color = new Color(0.5f, 0.75f, 0.82f);
                categories[3].GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
            foreach (GameObject o in categories)
            {
                if (o.GetComponent<Image>().color == new Color(0.5f, 0.75f, 0.82f))
                {
                    clickedAmount++;
                }
            }
            if (clickedAmount == 3)
            {
                startButton.SetActive(true);
                if(robotsTurn)
                {
                    OnStartButtonClicked();
                }
            }
            else
                startButton.SetActive(false);
        }
        else if (quiz_canvas.activeSelf)
        {
            wordsQuiz = GameObject.FindGameObjectsWithTag("word_quiz");
            if (wordsQuiz.Length == 0)
            {
                GameObject g = GameObject.FindGameObjectWithTag("prefab_parent");
                Destroy(g);
                Instantiate(prefab, wordsLayout.transform);
                wordsQuiz = GameObject.FindGameObjectsWithTag("word_quiz");
                start_canvas.SetActive(true);
                quiz_canvas.SetActive(false);
                if (robotsTurn == false)
                    robotsTurn = true;
                else
                {
                    robotsTurn = false;
                    robotCanMove = false;
                    EndGame();
                }
            }
        }
	}

    void EndGame()
    {
        startButton.SetActive(false);
        start_canvas.SetActive(false);
        quiz_canvas.SetActive(false);
        humanScoreText.text = playerScore+"";
        robotScoreText.text = robotScore+"";
        if (playerScore > robotScore)
            scoreMsg.text = "Human Inelligence Prevails!";
        else
            scoreMsg.text = "Sad Day for Humanity";
        scoreCanvas.SetActive(true);
    }

	public void OnStartButtonClicked()
	{
        Debug.Log("START");
        chosen.Clear ();
        foreach (GameObject o in categories)
        {
            if (o.GetComponent<Image>().color == new Color(0.5f, 0.75f, 0.82f))
            {
                chosen.Add(o.GetComponentInChildren<Text>().text);
            }
        }
        Debug.Log(wordsQuiz.Length);

        Debug.Log ("Category DONE");
		List<string> wordsGame = wa.CreateListForGame (chosen.ToArray());
		Debug.Log ("LIST IS CREATED");
		int i = 0;
		Debug.Log (chosen.Count);
		Debug.Log (categoriesQuiz.Length);
		foreach (GameObject go in categoriesQuiz) {
			go.GetComponentInChildren<Text> ().text = chosen [i];
			i++;
		}
		i = 0;
		foreach (GameObject go in wordsQuiz) {
			go.GetComponentInChildren<Text> ().text = wordsGame [i];
			i++;
		}

		start_canvas.SetActive (false);

		quiz_canvas.SetActive (true);

        if(robotsTurn)
        {
            robotCanMove = true;
            if (robotShouldWin)
                needPoints = playerScore + 1;
            else
                needPoints = playerScore - 1;
        }
        Debug.Log("NEED :" + needPoints);
        Debug.Log("Can Move: " + robotCanMove);
	}

    public void OnShouldWin()
    {
        GameObject winOrNot = GameObject.FindGameObjectWithTag("winOrNot");
        if (robotShouldWin)
        {
            robotShouldWin = false;
            winOrNot.GetComponent<Image>().color = new Color(0f,1f,0f,0.2f);
        }
        else
        {
            robotShouldWin = true;
            winOrNot.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.2f);
        }
    }

    void FixedUpdate()
    {
        if(robotCanMove)
        {
            RobotPlay();
        }
        if(quiz_canvas.activeSelf)
        {
            if (robotsTurn)
                textScore.GetComponent<Text>().text = robotScore+"";
            else
                textScore.GetComponent<Text>().text = playerScore+"";
        }
    }

    bool moving = false;
    int movingIndex = -1;
    System.Random rnd = new System.Random();
    GameObject[] allWords;

    Transform target;

    int needPoints = 0;
    bool firstEntry = true;

    public float robotSpeed = 10f;
    void RobotPlay()
    {
        if(firstEntry)
        {
            allWords = GameObject.FindGameObjectsWithTag("word_quiz");
            firstEntry = false;
        }
        if (!moving && (allWords.Length!=0))
        {
            firstEntry = false;
            allWords = GameObject.FindGameObjectsWithTag("word_quiz");
            if(allWords.Length == 0)
            {
                robotCanMove = false;
            }
            int index = rnd.Next()%allWords.Length;
            movingIndex = index;
            string correct_category = wa.GetCategoryOfWord(allWords[index].GetComponentInChildren<Text>().text);
            foreach(GameObject go in categoriesQuiz)
            {
                if (needPoints > robotScore)
                {
                    if (go.GetComponentInChildren<Text>().text == correct_category)
                    {
                        target = go.transform;
                        break;
                    }
                }
                else if (robotScore >= needPoints)
                {
                    if (go.GetComponentInChildren<Text>().text != correct_category)
                    {
                        target = go.transform;
                        break;
                    }
                }
            }
            moving = true;
        }
        else
        {
            if (allWords[movingIndex] != null)
            {
                float step = robotSpeed * Time.deltaTime;
                allWords[movingIndex].transform.position = Vector3.MoveTowards(allWords[movingIndex].transform.position, target.position, step);
            }
            else
            {
                moving = false;
            }
        }
    }

    public void RefreshButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
