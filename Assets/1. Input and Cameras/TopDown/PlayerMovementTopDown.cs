using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{	
	// Players rigid body component.
	private Rigidbody2D _rigidbody;
	// Player Input from the horizontal axis, Keys A and D / Left and Right arrows.
	private float _horizontalAxis;
	// Player Input from the horizontal axis, Keys W and S / Up and Down arrows.
	private float _verticalAxis;
	// Speed the player moves at.
	private float _speed = 500f;
	// Speed the player Jumps at.
	private float _jumpSpeed = 10f;
	
	// Use this for initialization
	void Start ()
	{
		// Gets the rigid body component of the player GameObject.
		_rigidbody = GetComponent<Rigidbody2D>();
		
	}

	// Update is called once per frame.
	void Update()
	{
		// If the space key is pressed down
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
			// Add jump power by adding a force to the rigid body.
			_rigidbody.AddForce(new Vector2(0, _jumpSpeed*25));
		
			// Add jump power by changing volicity on the y axis.
//			_rigidbody.velocity += new Vector2(0, _jumpSpeed);
		}
		
	}

	// Update is called once per physics step.
	void FixedUpdate ()
	{
		// Get the players horizontal axis input, this is the W and D keys, Left and Right arrow, or the left jostick on an xbox controller.
		// A float value between -1 and 1.
		_horizontalAxis = Input.GetAxis("Horizontal");
		_verticalAxis = Input.GetAxis("Vertical");
		
		// Get the players horizontal input like above.
		// GetAxis raw will return an integer between -1 and 1;
//		_horizontalAxis = Input.GetAxisRaw("Horizontal");
//		_verticalAxis = Input.GetAxisRaw("Vertical");
		
		
		// Set the velocity of the players rigid body to be the horizontal/vertical axis muliplied by the fixedDeltaTime and the player's speed.
		_rigidbody.velocity = new Vector2(_horizontalAxis * Time.fixedDeltaTime * _speed, _verticalAxis * Time.fixedDeltaTime * _speed);
	}
}
