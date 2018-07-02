using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private bool dirRight = false;
	public float speed = 3.0f;
	public float initX = 0;
	public float range = 30f;


	// Use this for initialization
	void Start () {
		initX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		// enemy move back and forth
		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if (transform.position.x <= initX - range) {
			dirRight = true;
			transform.localScale = new Vector2 (-2, 2);
		}
		if(transform.position.x >= initX) {
			dirRight = false;
			transform.localScale = new Vector2 (2, 2);
		}
	}
	void Bearposition(){
	//TODO: bear y position should update with sea level
	
	}

	void DetectPlyer(Collider2D col){
		MainGM.gm.resetPlayerPos ();

	}
	void OnTriggerEnter2D(Collider2D other)
	{
			
		if (other.gameObject.CompareTag("Player")) {
			
			DetectPlyer (other);

		}


	}
}
