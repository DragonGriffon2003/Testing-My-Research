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
	private QuestionData[] questionPool;
	private int questionIndex;
	public TextMeshPro questionText;

	public TextMeshPro scoreText;
	private int score;

	public SimpleObjectPool answerButtonObjectPooler;
	public Transform answerButtonParent;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	public Animator obstaclesAnimator;
	public float timeBetweenQuestions = 1f;

	private void Start()
	{
		questionPool = roundData.questions;
		questionPoolList.AddRange(roundData.questions);
		questionIndex = 0;
		SettingCurrentQuestion();
	}

	private void SettingCurrentQuestion()
	{
		RemoverAnswerButtons();
		QuestionData questionData = questionPoolList[questionIndex];
		questionText.text = questionData.questionText;

		questionText.text = questionData.questionText;
		questionPoolList.RemoveAt(questionIndex);

		for (int i = 0; i < questionData.answers.Length; i++)
		{
			GameObject answerButtonGameObject = answerButtonObjectPooler.GetObject();
			answerButtonGameObject.transform.SetParent(answerButtonParent);
			answerButtonGameObjects.Add(answerButtonGameObject);
			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup(questionData.answers[i]);
		}
	}
	private void RemoverAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0)
		{
			answerButtonObjectPooler.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
		StartCoroutine(TransitionToNextQuestion());
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

		if (questionPoolList.Count > questionIndex + 1)
		{
			questionIndex++;
			SettingCurrentQuestion();
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
		//questionPoolList.AddRange(roundData.questions);
	}
}
