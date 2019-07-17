using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

	public CharacterController myCharacterController;
	public float walkSpeed;


	private void Update()
	{
		// Get Horizontal and Vertical Input
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
	
		// Calculate the Direction to Move based on the tranform of the Player
		Vector3 moveDirectionForward = transform.forward * verticalInput * walkSpeed * Time.deltaTime;
		Vector3 moveDirectionSide = transform.right * horizontalInput * walkSpeed * Time.deltaTime;

		// Apply Movement to Player
		myCharacterController.SimpleMove(moveDirectionForward + moveDirectionSide);
	}

}