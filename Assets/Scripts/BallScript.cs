using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

//	public KeyCode newBall = KeyCode.Space; //assigning the key for the ball respawn
	[SerializeField] //makes it editable in the inspector
	float forceValue = 4.5f; //so we can edit this more easily
	public GameObject newBall;
	Rigidbody2D myBody;
	// Use this for initialization

	void Start () {
		myBody = GetComponent<Rigidbody2D>(); //find the rigidbody
		myBody.AddForce (new Vector2 (forceValue * 125, 125)); //give it force
	}//END START


	// Update is called once per frame



	public void Reset()
	{
		// reset the ball position and restart the ball movement
		myBody.velocity = Vector2.zero;
		transform.position = new Vector2(0,0);
		Start(); // restart the ball 
	}//END RESET

}//END SCRIPT
