using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	//Variables
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 180.0f;
	private float pitch = 0.0f;

	public bool canMove = false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 18f;
	private Vector3 moveDirection = Vector3.zero;

	private void Start()
	{

		//transform.eulerAngles = new Vector3 (0f, 180f, 0f);
	}

	void Update()
	{
		CharacterController controller = GetComponent<CharacterController>();
		// is the controller on the ground?
		if (controller.isGrounded)
		{
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		
		//Making the character move only if this bool funtion is true
		if (canMove == true)
		{
			//Debug.Log("canMove = true");
			controller.Move(moveDirection * Time.deltaTime);
		}
		if (Input.GetMouseButton(1))
		{
			yaw += speedH * Input.GetAxis("Mouse X");
			pitch -= speedV * Input.GetAxis("Mouse Y");
			transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		}

	}
}