using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EventSystem : MonoBehaviour, IPointerClickHandler
{
	public MoveCamera moveCamera;
	//public ScreenController screenController;
	public Animator obstaclesAnimator;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.pointerCurrentRaycast.gameObject.tag == "StartButton")
		{
			moveCamera.canMove = true;
			obstaclesAnimator.SetInteger("Stage", 2);
		}
		/*
		if (pointerEventData.pointerCurrentRaycast.gameObject.tag == "QuizButton")
		{
			//obstaclesAnimator.SetInteger("Stage", 2);

			//ScreenController.StartGame();
		}*/
	}
	
}