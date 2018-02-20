using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
	// Stores the object that has been clicked on so the position can be changed.
	private GameObject _selectedObject;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) // If the left mouse button is pressed down.
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cast a ray from the mouse position to the screen.
			RaycastHit hit; // Stores the information if the mouse its anything.

			if (Physics.Raycast(ray, out hit)) // Check if the ray hits any objects.
			{
				Debug.Log(hit.collider.name); // Output the name of the object hit by the mouse ray.
				_selectedObject = hit.collider.gameObject; // store the game object of the object clicked on by mouse.
			}
		}

		if (Input.GetMouseButton(0)) // if the mouse left click if held down
		{
			if (_selectedObject != null) // if a gameobject has been clicked on and exists.
			{
				Vector2 mousePositionInGame = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Store the position of the mouse relative to the world.
				
				// set the postion of the clicked on object to the mouse position, keeping the Z value the same.
				_selectedObject.transform.position = new Vector3(mousePositionInGame.x, mousePositionInGame.y, _selectedObject.transform.position.z);
			}
		}

		if (Input.GetMouseButtonUp(0)) // if the left mouse button is released.
		{
			_selectedObject = null; // set the selected object to null.
		}

	}
	
	
}
