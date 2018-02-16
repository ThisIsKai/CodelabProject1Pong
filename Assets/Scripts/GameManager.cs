using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour {

	int playerOneScore, playerTwoScore;
	Text ScoreText;
	private List<BallScript> balls;
	public GameObject ballPrefab;
	public Vector3 ballSpawnPoint;
	public float zoomOutFactor;
	public Transform walls;
	private float paddleDistance;
	public PaddleScript[] paddles;
	private GoalScript[] goals;
	public SceneManager[] sm;


	public static GameManager instance = null;

	public int score = 0;


	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text> ();
		goals = walls.GetComponentsInChildren<GoalScript>();
		paddleDistance = paddles [0].transform.position.x - goals [0].GetComponent<BoxCollider2D> ().bounds.max.x;
		balls = new List<BallScript> ();
		StartGame ();
	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			instance.playerOneScore = 0;
			instance.playerTwoScore = 0;

			Destroy(gameObject); // THERE CAN BE ONLY ONE!
		}
		
	}//END START

	// Update is called once per frame
	void Update () {
	ScoreText.text = "Score" + "Player One" + playerOneScore + "Player Two" + playerTwoScore;
		if (Input.GetKeyDown (KeyCode.Space))
			StartGame ();

	}//END UPDATE

	void GameOver()	{
		if (playerOneScore > playerTwoScore) {
			sm.LoadScene ("PlayerOneWinner");
		}
	
			else if { (playerOneScore < playerTwoScore) 
			sm.LoadScene ("PlayerTwoWinner");
		}
		// display game win text saying "player 1 wins" or whatever

	}//END GAMEOVER

	void StartGame(){
		for (int i = balls.Count -1; i >= 0; i--) {
			DestroyBall (balls [i]);
		}
//		playerOneScore = 0; //set player one's starting score to 0
//		playerTwoScore = 0;//set player two's starting score to 0
		balls = new List<BallScript>();
		AddBall ();
	}

	public void GoalScored(int playerNumber) {
		// increase the score for whichever player scored
		AddBall();
		if (playerNumber == 1)
			GameManager.instance.playerOneScore++;
		else if (playerNumber == 2)
			GameManager.instance.playerTwoScore++;
		// then check if the player has won
		if (playerOneScore >= 10)
			GameOver (1);
		else if (playerTwoScore >= 10)
			GameOver (2);

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
	}

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
	}
		
}//END SCRIPT

