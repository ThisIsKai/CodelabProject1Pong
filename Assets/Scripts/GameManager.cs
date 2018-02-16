using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

	int playerOneScore, playerTwoScore;
	//Text ScoreText;
	private List<BallScript> balls;
	public GameObject ballPrefab;
	public Vector3 ballSpawnPoint;
	public float zoomOutFactor;
	public Transform walls;
	private float paddleDistance;
	public PaddleScript[] paddles;
	private GoalScript[] goals;
	public  SceneManager[] sm;

	public static GameManager instance = null;
	public int score = 0;

	void Start () {
//	sm = SceneManager;  //assign a abbriviation for scene manager
	//	ScoreText; // the text component
		goals = walls.GetComponentsInChildren<GoalScript> (); //find the goals by finding the objects with the goal script attached to them
		paddleDistance = paddles [0].transform.position.x - goals [0].GetComponent<BoxCollider2D> ().bounds.max.x; //find the distance between the paddles and the goal walls
		balls = new List<BallScript> (); //make a list to keep all the new balls in
		StartGame (); //run the start function



		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}//end if
		else {
			instance.playerOneScore = 0;
			instance.playerTwoScore = 0;
			Destroy(gameObject); 
		}//end else
		
	}//END START

	void Update () {
//		ScoreText = "Score" + "Player One" + playerOneScore + "Player Two" + playerTwoScore; //tell the text what to display
//		if (Input.GetKeyDown (KeyCode.Space)){ //if the spacebar is pressed then
//		StartGame ();//start the game
	}//END UPDATE

	void GameOver()	{
//		if (playerOneScore > playerTwoScore) { //if playerone's score is greater than playertwo's
//			sm.LoadScene ("PlayerOneWinner"); //then load the 'PlayerOneWinner' scene 
//		}//end if1
//	
//			else {
//				sm.LoadScene ("PlayerTwoWinner"); //then load the 'PlayerTwoWinner's scene 
//			}//end if2
//				
	}//END GAMEOVER

	void StartGame(){
		for (int i = balls.Count -1; i >= 0; i--) { 
			DestroyBall (balls [i]);
		}//end for ball loop
//		playerOneScore = 0; //set player one's starting score to 0
//		playerTwoScore = 0;//set player two's starting score to 0
		balls = new List<BallScript>(); 
		AddBall ();
	}//END STARTGAME

	public void GoalScored(int playerNumber) { // increase the score for whichever player scored
		AddBall(); 
		if (playerNumber == 1)
			GameManager.instance.playerOneScore++;
		else if (playerNumber == 2)
			GameManager.instance.playerTwoScore++;
		// then check if the player has won
		if (playerOneScore >= 10)
			GameOver ();
			
		else if (playerTwoScore >= 10)
			GameOver ();

	}//END GOAL SCORED


	void AddBall () {

		GameObject newBallObj = Instantiate(ballPrefab);
		newBallObj.transform.position = ballSpawnPoint;
		balls.Add (newBallObj.GetComponent<BallScript> ());
		ZoomOut ();

	}//END IF NEW BALL

	void DestroyBall(BallScript ball){
		balls.Remove (ball);
		Destroy (ball.gameObject);
	}//END DESTROY BALL

	void ZoomOut(){
		Camera.main.orthographicSize *= zoomOutFactor;
		walls.localScale *= zoomOutFactor;
		float paddleXPos1 = goals [0].GetComponent<BoxCollider2D> ().bounds.max.x + paddleDistance;
		paddles [0].transform.position = new Vector3 (paddleXPos1, paddles [0].transform.position.y, paddles [0].transform.position.z);
		float paddleXPos2 = goals [1].GetComponent<BoxCollider2D> ().bounds.min.x - paddleDistance;
		paddles [1].transform.position = new Vector3 (paddleXPos2, paddles [1].transform.position.y, paddles [1].transform.position.z);
//		for (int i = 0; i < paddles.Length; i++) {
//			float xPos;
//			if(i == 0){
//				xPos = goals [0].GetComponent<BoxCollider2D> ().bounds.max.x + paddleDistance;
//			}
//			else{
//				xPos = goals [1].GetComponent<BoxCollider2D> ().bounds.min.x - paddleDistance;
//			}
//			paddles [i].transform.position = new Vector3 (xPos, paddles [i].transform.position.y, paddles [i].transform.position.z);
//
//		}
	}//END ZOOM OUT
		
}//END SCRIPT

