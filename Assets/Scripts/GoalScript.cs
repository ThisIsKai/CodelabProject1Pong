﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

	[SerializeField]
	int attackingPlayer; // which player scores into this goal
	[SerializeField]
	GameManager gameMan; // this is a reference to the game manager script


	void Start () {
	}//END START

	void OnCollisionEnter2D(Collision2D other) { //collision function, for when ball hits wall behind player
		if(other.transform.name == "Ball") { //if the name of the object is 'ball' 
			gameMan.GoalScored(attackingPlayer); //is it attacking player (ref. bool)
			other.gameObject.GetComponent<BallScript>().Reset(); //run the reset function on the ball object
		} //end if object is ball 
	} // END ON COLLISION
}//END SCRIPT
