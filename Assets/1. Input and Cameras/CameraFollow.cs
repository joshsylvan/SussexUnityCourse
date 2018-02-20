using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public bool Lerp, Move; // Used for toggling different modes not needed in actual game.
	private GameObject _target; // target for the camera to follow.

	private float _cameraLerpSpeed = 2.5f, _cameraMoveSpeed = 25f; // Camera movement speeds.
	
	// Use this for initialization
	void Start () {
		// Find the object with the tag Player in the hierarchy.
		_target = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if (!Lerp && !Move)
		{
			// Traditional set the camera to the players position with the offset -10 so the camera stays in the same deapth
			transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
		}
	}
	
	// FixedUpdate is called once per physics step
	void FixedUpdate ()
	{
		if (Lerp)
		{
			// Camera Lerping movement
			Vector3 newCameraPosition = Vector3.Lerp(transform.position, _target.transform.position, Time.fixedDeltaTime * _cameraLerpSpeed);
			transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, -10);
		}
		else if(Move)
		{
			// Camera smooth movement
			Vector3 newCameraPosition = Vector3.MoveTowards(transform.position, _target.transform.position, Time.fixedDeltaTime * _cameraMoveSpeed);
			transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, -10);
		}
	}
}
