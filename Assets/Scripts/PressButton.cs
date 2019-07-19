using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


public class PressButton: MonoBehaviour
{
	//When attached to an object with a collider, and pressed, it will invoke that funtion. 
	[SerializeField] UnityEvent anEvent;
	private void OnMouseDown()
	{
		anEvent.Invoke();
	}

}
