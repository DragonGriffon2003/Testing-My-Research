using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
	public MoveCamera moveCamera;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "MainCamera")
		{
			moveCamera.canMove = false;
			gameObject.GetComponentInChildren<Renderer>().enabled = true;
		}
	}
}
