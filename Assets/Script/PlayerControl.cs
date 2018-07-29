using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private float force ;
	private float weight;
	private Rigidbody2D myrigi;

	//
	public ParticleSystem ps;
	public GameObject treePrefb;
	private float currentenergy;
	// Use this for initialization
	void Start () {
		//TODO: turn those two comment on when testing whole game
		weight = Player.GetWeight ();
		force = weight*0.8f;//weight;//F = m*g
		//force =40.0f;
		myrigi = GetComponent<Rigidbody2D>();
		currentenergy = Player.GetFart ();
		
	}
	
	// Update is called once per frame
	void Update () {
		currentenergy = Player.GetFart ();
		fixedupdate ();
	}
	void fixedupdate (){
		bool getfarting = Input.GetButton ("Jump");
		bool moving = Input.GetButton ("Horizontal");
		float moveHorizontal = Input.GetAxis ("Horizontal")*Time.deltaTime*10.0f;
		if (getfarting) {
			if (currentenergy > 0.0f) {
				myrigi.AddForce (new Vector2 (moveHorizontal, force));
				ps.Play ();
				DetectGreenGas (.05f, -0.1f);
			} else {
				myrigi.AddForce (new Vector2 (moveHorizontal, 0.0f));	
			
			}
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
		vegs += .5f;
		Player.SetFart (vegs);
		vegs = Player.GetGGas ();
		vegs -= 2.0f;
		Player.SetGGas (vegs);
		string tmp = collider.gameObject.name;
		Vector3 pos = collider.gameObject.transform.position;
		Destroy (collider.gameObject);
		createTree (pos, tmp); 


	
	}
	void createTree(Vector3 position, string vegs){
		string name = "tree"+vegs;
		GameObject spawnTree = Instantiate (treePrefb, position, Quaternion.identity);
		spawnTree.transform.position = position;
		spawnTree.name = name;

	}

	void Meat(Collider2D collider){
		//use collider.gameObject.name yo distinguish what kind of meat //	
		float meat = Player.GetFart();
		meat += 1.0f;
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
		else if(other.gameObject.CompareTag("Meat")){
			Meat(other);
		}

	}
}
