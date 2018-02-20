using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKeyboardMovement : MonoBehaviour
{
	// Player Input from the horizontal and vertical axis.
	// Horizontal direction used by the keys A and D in this example.
	// Vertical direction used by the keys W and S in this example.
	private int _horizontalDirection = 0, _verticalDirection = 0;
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.W)) // Checks if the W key is being held down.
		{
			_verticalDirection = 1; // if S is held down vertical direction is 1 (up)
		} 
		else if (Input.GetKey(KeyCode.S)) // Checks if the S key is being held down.
		{
			_verticalDirection = -1; // if S is held down vertical direction is -1 (down)
		}
		else // if the keys W or S are not being held down then the players vertical direction is 0
		{
			_verticalDirection = 0;
		}
		
		if (Input.GetKey(KeyCode.A)) // Checks if the A key is being held down.
		{
			_horizontalDirection = -1; // if A is held down horizontal direction is -1 (left)
		} 
		else if (Input.GetKey(KeyCode.D)) // Checks if the D key is being held down.
		{
			_horizontalDirection = 1; // if D is held down horizontal direction is 1 (right)
		}
		else
		{
			_horizontalDirection = 0; // if the keys A or D are not being held down then the players horizontal direction is 0
		}
		
		// set the position of this GameObject (Camera) to the cameras position plus the horizontal and vertical directions.
		transform.position = new Vector3(
			transform.position.x + _horizontalDirection,
			transform.position.y + _verticalDirection,
			transform.position.z
		);
	}
}
