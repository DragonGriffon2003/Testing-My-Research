using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager2 : MonoBehaviour
{

	public TextMeshPro scoreDisplayText;
	public TextMeshPro questionText;
	public SimpleObjectPool optionObjectPool;
	public Transform answerButtonParent;
	public ScreenController screenController;
	public Animator obstaclesAnimator;
	public RoundData roundData;
	public float timeBetweenQuestions = 1f;

	private RoundData currentRoundData;
	private QuestionData[] questionPool;
	public List<QuestionData> questionPoolList;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();
	/*
	public RoundData GetCurrentRoundData()
	{
		return allRoundData[0];
	}*/
	private void Start()
	{
		//currentRoundData = GetCurrentRoundData();
		questionPool = currentRoundData.questions;
		questionPoolList.AddRange(currentRoundData.questions);
		playerScore = 0;
		questionIndex = 0;
		SetCurrentQuestion();
	}
	
	//Sets random question
	public void SetCurrentQuestion()
	{
		RemoverAnswerButtons();

		//int randomQuestionIndex = Random.Range(0, questionPool.Length);
		//QuestionData questionData = questionPool[randomQuestionIndex];

		//int randomQuestionIndex = Random.Range(0, questionPoolList.Count);
		//QuestionData questionData = questionPoolList[randomQuestionIndex];

		QuestionData questionData = questionPoolList[questionIndex];
		questionText.text = questionData.questionText;

		questionText.text = questionData.questionText;
		questionPoolList.RemoveAt(questionIndex);

		for (int i = 0; i < questionData.answers.Length; i++)
		{
			GameObject answerButtonGameObject = optionObjectPool.GetObject();
			answerButtonGameObject.transform.SetParent(answerButtonParent);
			answerButtonGameObjects.Add(answerButtonGameObject);
			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup(questionData.answers[i]);
		}
	}

	//Resets the answer buttons
	private void RemoverAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0)
		{
			optionObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
		StartCoroutine(TransitionToNextQuestion());		
	}

	//Checks wether the button clicked is correct or not, and then loads the next round
	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect)
		{
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString();
		}

		if (questionPoolList.Count> questionIndex + 1)
		{
			questionIndex++;
			SetCurrentQuestion();
		}
		else
		{
			EndRound();
		}	

	}
	
	public void EndRound()
	{
		obstaclesAnimator.SetInteger("Stage", 3);
		questionIndex = 0;
		screenController.SetEndActive();
		questionPoolList.AddRange(currentRoundData.questions);
	}
	
	IEnumerator TransitionToNextQuestion()
	{
		yield return new WaitForSeconds(timeBetweenQuestions);
	}
	
}
