using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	int playerOneScore, playerTwoScore;

	[SerializeField]
	BallScript gameBall;

	// Use this for initialization
	void Start () {
		playerOneScore = 0; //set player one's starting score to 0
		playerTwoScore = 0;//set player two's starting score to 0
	

		
	}//END START

	// Update is called once per frame
	void Update () {

	}//END UPDATE

	void GameOver(int winner)
	{
		// this is called when a player reaches 3 points 

		// reset the scores
		playerOneScore = 0;
		playerTwoScore = 0; 
		gameBall.Reset ();
	}



	public void GoalScored(int playerNumber)

	{
		// increase the score for whichever player scored
		if(playerNumber == 1)
			playerOneScore++;
		else if (playerNumber ==2)
			playerTwoScore++;

		// now check if the player has won
		if(playerOneScore == 3)
			GameOver(1);
		else if (playerTwoScore ==3)
			GameOver(2);

	}


}//END SCRIPT
