using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

//	public KeyCode newBall = KeyCode.Space; //assigning the key for the ball respawn
	[SerializeField] //makes it editable in the inspector
	float forceValue = 4.5f; //so we can edit this more easily
	public GameObject newBall; //the balls that will be added
	Rigidbody2D myBody; //the rigidbody attached to the gameobject

	void Start () {
		myBody = GetComponent<Rigidbody2D>(); //find the rigidbody
		myBody.AddForce (new Vector2 (forceValue * (Random.Range(-150,150)), (Random.Range(-150,150)))); //give it force
	}//END START
		
	public void Reset() { // reset the ball position and restart the ball movement
		myBody.velocity = Vector2.zero; //give no force to the rigidbody here
		transform.position = new Vector2(0,0); //and again, no force or movement
		Start(); // restart the ball 
	}//END RESET

}//END SCRIPT
