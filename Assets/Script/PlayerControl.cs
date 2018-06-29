using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private float force ;
	private float weight;
	private Rigidbody2D myrigi;
	//
	public ParticleSystem ps;
	// Use this for initialization
	void Start () {
		//weight = Player.GetWeight ();
		force = 50;//weight;//F = m*g
		myrigi = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		fixedupdate ();
	}
	void fixedupdate (){
		bool getfarting = Input.GetButton ("Jump");
		bool moving = Input.GetButton ("Horizontal");
		float moveHorizontal = Input.GetAxis ("Horizontal")*Time.deltaTime*10.0f;
		if (getfarting) {
			myrigi.AddForce (new Vector2 (moveHorizontal, force));
			ps.Play ();
			DetectGreenGas (.05f, -0.1f);
			//ps.enableEmission = true;
		}
		if (moving) {

			transform.Translate (moveHorizontal, 0, 0);
		}



	}
	void DetectGreenGas(float power, float fart){
		float currentGGS = Player.GetGGas();
		currentGGS += power;
		Player.SetGGas (currentGGS);
		float currentF = Player.GetFart ();
		currentF += fart;
		Player.SetFart (currentF);

	}
	void EatFood(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Fruit")) {
		
			Vegs (collider);
		}
		else {
			Meat(collider);
		}
	}
	void Vegs(Collider2D collider)
	{
		//use collider.gameObject.name yo distinguish what kind of vegs //	
		float vegs = Player.GetFart();
		vegs += 1.0f;
		Player.SetFart (vegs);
		Destroy (collider.gameObject);

	
	}

void Meat(Collider2D collider){
		//use collider.gameObject.name yo distinguish what kind of meat //	
		float meat = Player.GetFart();
		meat += 2.0f;
		Player.SetFart (meat);
		meat = Player.GetGGas () + 1.0f;
		Player.SetGGas (meat);
		Destroy (collider.gameObject);
	}
void OnTriggerEnter2D(Collider2D other)
{
		if (other.gameObject.CompareTag("Fruit")) {

			Vegs (other);
		}
		else {
			Meat(other);
		}

}
}
