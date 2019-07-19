using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOverMouse : MonoBehaviour
{
	private Renderer renderer;
	public Color color;
	public Color colorOriginal;

	//public Color color;

	private void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	void OnMouseOver()
	{
		renderer.material.color = color;
	}

	void OnMouseExit()
	{
		renderer.material.color = colorOriginal;
	}
}
