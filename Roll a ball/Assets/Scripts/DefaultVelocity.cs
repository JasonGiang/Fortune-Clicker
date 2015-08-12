using UnityEngine;

using System.Collections;



public class DefaultVelocity : MonoBehaviour {
	
	// The Velocity (can be set from Inspector)
	
	public Vector2 velocity;

	
	

	void FixedUpdate () {

		//this sets velocity of the rigidbody attached to the object to velocity that you set in the inspector.

		GetComponent<Rigidbody2D>().velocity = velocity;

		
	}
	
}