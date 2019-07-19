using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
	public ScreenController screenController;
	public RoundData roundData;
	public List<QuestionData> questionPoolList;
	//private QuestionData[] questionPool;
	private int questionIndex;
	public TextMeshPro questionText;
	//public List<GameObject> answerButtonsGameObjects;
	
	public TextMeshPro scoreText;
	public TextMeshPro endScoreText;
	public TextMeshPro closeGameText;
	private int score;

	public Transform answerButtonParent;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();
	public bool passedStage;
	public float timeBetweenQuestions = 1f;

	private void Start()
	{
		//questionPool = roundData.questions;
		questionPoolList.AddRange(roundData.questions);
		questionIndex = 0;
		SettingCurrentQuestion();
	}

	private void SettingCurrentQuestion()
	{
		QuestionData questionData = questionPoolList[questionIndex];
		questionText.text = questionData.questionText;
		questionPoolList.RemoveAt(questionIndex);

	}

	IEnumerator TransitionToNextQuestion()
	{
		yield return new WaitForSeconds(timeBetweenQuestions);
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect)
		{
			score += roundData.pointsAddedForCorrectAnswer;
			scoreText.text = "Score: " + score.ToString();
		}

		if (isCorrect)
		{

		}

			if (questionPoolList.Count > questionIndex + 1)
		{
			questionIndex++;
			SettingCurrentQuestion();
			StartCoroutine(TransitionToNextQuestion());
		}
		else
		{
			EndRound();
		}

	}

	public void EndRound()
	{
		questionIndex = 0;
		screenController.SetEndActive();
		endScoreText.text = "Score: " + score;
		if (score >= 20)
		{
			passedStage = true;
			closeGameText.text = "You passed" + "Press to continue";
		}
		else
		{
			passedStage = false;
			closeGameText.text = "You failed" + "Press to continue"; ;
		}
		//questionPoolList.AddRange(roundData.questions);
	}
	/*
	public void UserSelectTrue()
	{
		
	}*/
}
