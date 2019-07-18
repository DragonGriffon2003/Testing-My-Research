using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystem : MonoBehaviour, IPointerClickHandler
{
	public MoveCamera moveCamera;

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.pointerCurrentRaycast.gameObject.tag == "StartButton")
		{
			//Camera.main.GetComponent<MoveCamera>().canMove = true;
			moveCamera.canMove = true;
		}
	}
}