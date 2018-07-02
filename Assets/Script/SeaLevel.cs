using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLevel : MonoBehaviour {

//	public bool isRaise = false;
	private float speed = 0.05f;
	private float check;


	// Update is called once per frame
	void Start(){

		check = Player.GetFart ();

	}
	void Update () {
		float tmp = Player.GetGGas ();

		if (check != tmp) {
			if (check > tmp)
				movingSea (-tmp);//go down, depand on greenhouse gas
			else
				movingSea (tmp);//go up
			check = tmp;
		}
		DetectPlayer ();

	}
	void movingSea(float gasLevel){		
			//float currentLevel = transform.position.y;
			transform.Translate (Vector2.up * speed * gasLevel * Time.deltaTime);

	}
	void DetectPlayer(){
		//TODO: have to add cllider, to detect player inside sea or not, yes => die
		//same method as Enemy
	}
}
