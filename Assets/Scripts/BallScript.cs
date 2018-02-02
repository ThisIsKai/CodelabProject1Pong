using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
	[SerializeField] //makes it editable in the inspector
	float forceValue = 4.5f; //so we can edit this more easily

	Rigidbody2D myBody;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>(); //find the rigidbody
		myBody.AddForce (new Vector2 (forceValue * 125, 125)); //give it force
	
	}//END START

	// Update is called once per frame
	void Update () {

	}//END UPDATE

	public void Reset()
	{
		// reset the ball position and restart the ball movement
		myBody.velocity = Vector2.zero;
		transform.position = new Vector2(0,0);
		Start(); // restart the ball 
	}

}//END SCRIPT
