using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Click : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Material material;
	public TextMeshPro text;

	/*
	public void OnMouseOver()
	{
		material.color = Color.red;
	}

	private void OnMouseExit()
	{
		material.color = Color.green;

	}*/

	public void ChangeColor()
	{
		material.color = Color.cyan;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		text.text = "Clicked";
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		text.text = "Hovering";
		material.color = Color.cyan;
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		text.text = "Normal";
		material.color = Color.red;
	}


	public void OnPointerDown(PointerEventData eventData)
	{

	}

}
