using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
	public Renderer[] rs;

	private void Start()
	{
		rs = GetComponentsInChildren<Renderer>();
		ChildRendererEnable(false);
	}
	
	public void OnTriggerEnter(Collider other)
	{
		other.transform.position = new Vector3 (gameObject.transform.position.x, other.transform.position.y, gameObject.transform.position.z);
		other.GetComponent<MoveCamera>().canMove = false;
		ChildRendererEnable(true);
	}

	void ChildRendererEnable(bool enabledState)
	{
		foreach (Renderer r in rs)
		{
			r.enabled = enabledState;
		}
	}
}
