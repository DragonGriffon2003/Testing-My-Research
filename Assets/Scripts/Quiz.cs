using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
public class Quiz : MonoBehaviour
{
	[System.Serializable]
	public class Questions
	{
		public string question;
		public bool isTrue;
	}

	public Questions[] questions;
	private List<Questions> unansweredQuestions;
	private Questions currentQuestion;
	[SerializeField]
	private TextMeshPro questionText;

	public int scorePoints;
	public TextMeshPro scoreText;
	public TextMeshPro finalScoreText;

	public bool passedStage;
	private Scene scene;

	public GameObject startScreen;
	public GameObject gameScreen;
	public GameObject endScreen;


	//Sets all the screens off in the start of the game
	private void Start()
	{
		//FInding and adding the correct obejcts in the correct varables
		scene = SceneManager.GetActiveScene();
		startScreen = GameObject.Find("Menu");
		gameScreen = GameObject.Find("Game");
		endScreen = GameObject.Find("End");
		questionText = GameObject.Find("QuestionText").GetComponent<TextMeshPro>();
		scoreText = GameObject.Find("ScoreDisplay").GetComponent<TextMeshPro>();
		finalScoreText = GameObject.Find("FinalScoreDisplay").GetComponent<TextMeshPro>();

		scorePoints = 0;
		unansweredQuestions = questions.ToList<Questions>();
		SetStartActive();
		StartScene();
	}

	void StartScene()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			CloseGame();
		}
		setCurrentQuestion();
		updateScore();
	}

	void updateScore()
	{
		scoreText.text = "Score: " + scorePoints;
	}
	public void AddScore(int newScore)
	{
		scorePoints += newScore;
		updateScore();
	}

	void setCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		questionText.text = currentQuestion.question;
	}

	void Transition()
	{
		unansweredQuestions.Remove(currentQuestion);
		if (scorePoints >= 30)
		{
			passedStage = true;
			finalScoreText.text = "Score: " + scorePoints;
			Debug.Log("Passed");
			StartScene();
		}
		else
		{
			passedStage = false;
			StartScene();
		}


	}

	public void UserSelectTrue()
	{
		if (currentQuestion.isTrue)
		{
			Debug.Log("correct");
			AddScore(10);
		}
		else
		{
			Debug.Log("incorrect");
		}
		Transition();
	}
	public void UserSelectFalse()
	{
		if (!currentQuestion.isTrue)
		{
			Debug.Log("correct");
			AddScore(10);
		}
		else
		{
			Debug.Log("incorrect");
		}
		Transition();
	}

	public void CloseGame()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);
		if (passedStage == true)
			SetEndActive();
		else
			RestartScene();
	}

	public void SetStartActive()
	{
		startScreen.SetActive(true);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);
	}

	public void SetGameActive()
	{
		Debug.Log("Game start");
		startScreen.SetActive(false);
		gameScreen.SetActive(true);
		endScreen.SetActive(false);
	}

	public void SetEndActive()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(false);
		endScreen.SetActive(true);
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(scene.name);
	}
}
