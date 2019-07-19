using UnityEngine;
using System.Collections;
using TMPro;

public class AnswerButton : MonoBehaviour
{

	public TextMeshPro answerText;
	private AnswerData answerData;
	private GameManager gamemanager;

	// Use this for initialization
	void Start()
	{
		gamemanager = FindObjectOfType<GameManager>();
	}

	public void Setup(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void OnMouseDown()
	{
		HandleClick();
	}
	
	public void HandleClick()
	{
		gamemanager.AnswerButtonClicked(answerData.isCorrect);
	}
}