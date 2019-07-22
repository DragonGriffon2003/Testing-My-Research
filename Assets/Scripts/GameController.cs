using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Question[] questions;
	private List<Question> unansweredQuestions;

	private Question currentQuestion;

	[SerializeField]
	private TextMeshPro questionText;

	public int scorePoints;
	public TextMeshPro scoreText;

	//public Animator obstaclesAnimator;
	public ScreenController screenController;
	public bool passedStage;
	private Scene scene;
	void Start()
	{
		scene = SceneManager.GetActiveScene();
		scorePoints = 0;
		unansweredQuestions = questions.ToList<Question>();
		StartScene();
	}

	void StartScene()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		{
			screenController.CloseGame();
			//Debug.Log("RESTARTED");			
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
		StartScene();

		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
		{			
			screenController.CloseGame();
		}

		if (scorePoints >= 30)
			passedStage = true;
		else if (unansweredQuestions.Count == 0)
			 SceneManager.LoadScene(scene.name);
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

}