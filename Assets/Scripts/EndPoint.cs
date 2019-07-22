using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
	//public MoveCamera moveCamera;
	//public Renderer childRenderer;
	
	public void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		other.GetComponent<MoveCamera>().canMove = false;
		//childRenderer.enabled = true;
		gameObject.GetComponentInChildren<Renderer>().enabled = true;
	}
	
}
