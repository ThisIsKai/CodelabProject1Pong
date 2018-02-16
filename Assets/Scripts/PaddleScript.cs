using System.Collections;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
	
	[SerializeField] 	//makes it editable in the inspector
	bool isPlayerTwo;	 //is it player two or not
	[SerializeField] 	//makes it editable in the inspector
	float speed = 0.2f;       // paddle speed
	Transform myTransform;    // reference to the object's transform
	int direction = 0; // 0 = not moving, 1= up, -1 = down
	float previousPositionY; //previous y pos of paddle
//	public KeyCode upKey;   // making it variable more easily editable in the inspector
//	public KeyCode downKey; // making it variable more easily editable in the inspector



	void Start () {
		myTransform = transform; // define myTransform
//		previousPositionY = myTransform.position.y; //comparison of posistion
	}//END START

	// FixedUpdate is called once per physics tick/frame
	void FixedUpdate () {
		if (isPlayerTwo) { // is this player 2?
			if (Input.GetKey ("o"))//make o the up key for player2
				MoveUp (); // 
			else if (Input.GetKey ("l")) //make l the down key for player2
				MoveDown (); //
		}	//end player 2 control scheme
		else { // if it's not player 2 (making it player1)
			if (Input.GetKey ("q")) //make q the up key for player1
				MoveUp ();
			else if (Input.GetKey ("a"))
				MoveDown (); //make a the down key for player2
		}//end player 1 control scheme

		if (previousPositionY > myTransform.position.y) //indicating direction of movement based
														//on the comparison of the two posistions
			direction = -1;
		else if (previousPositionY < myTransform.position.y)
			direction = 1;
		else
			direction = 0;

	}//END FIXED UPDATE
		
	void MoveUp() { // move the player's paddle down by an amount determined by 'speed'
		myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed); // move up
	}//END MOVE UP

	void MoveDown() {// move the player's paddle down by an amount determined by 'speed'
		myTransform.position = new Vector2 (myTransform.position.x, myTransform.position.y - speed); //move down
	}//END MOVE DOWN

//	void LateUpdate() {
//		previousPositionY = myTransform.position.y; //comparing last posistion
//	}//LATE UPDATE
}//END SCRIPT