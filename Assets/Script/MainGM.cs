using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//including all the UI msg update
public class MainGM : MonoBehaviour {
	public static MainGM gm = null;//set this let other script be acessed
	public Slider GGSBar;
	public Slider FartBar;
	public Image LivePref;
	public GameObject playerInipos;
	public GameObject seaObj;

	public Canvas sUI;

	private float initFart = 50f;

	private float initGas = 50f;
	private Vector3 IniPosion;
	private Vector3 iniSeaLevel;


	private int initLive = 3;


	// Use this for initialization
	void Awake () {
		if (gm == null)
			gm = this;

		IniPosion = playerInipos.transform.position;
		iniSeaLevel = seaObj.transform.position;
		Refresh ();
	}

	
	// Update is called once per frame
	void Update () {
		UpdateScreenUI ();
	}
	void Refresh(){
		setDefault ();
		Player.UnlockedLevel ();
	}
	public void load(string name){
		SceneManager.LoadScene (name);
	}
	void setDefault()
	{
		Player.SetFart (initFart);
		Player.SetGGas (initGas);
		Player.SetLives (initLive);
		float GGs = Player.GetGGas();
		GGSBar.value = GGs;
		LivesGenerates ();
	}
	void UpdateScreenUI(){
		float currentGGS = Player.GetGGas();
		GGSBar.value = currentGGS;

		float currentF = Player.GetFart ();
		FartBar.value = currentF;



		if(currentGGS >= 99.0f )//max greenhouse the die
		{   int currentL = Player.GetLives();
			
			if(currentL != 0)
			{	
				GameObject[] destroyL = GameObject.FindGameObjectsWithTag("Lives");
				currentL--;
				Destroy(destroyL[currentL]);
				Player.SetLives(currentL);

			}
			else
			{
				load("GameOver");
			}

		}
		if(currentGGS <= 20.0f)//save the world
			load("Level2");

	}
	void LivesGenerates(){
		int totalLives = Player.GetLives ();
		for (int i = 0; i < totalLives; i++) {
			string names = "Live" + i;
			Vector3 v = new Vector3 ( 120 + (i * 50), -50, 0);
			Image L = Instantiate (LivePref, v, Quaternion.identity);
			L.transform.position = v;//my version need this line, otherwise i counld't get right position
			RectTransform uitransform = L.GetComponent<RectTransform>();
			uitransform.anchorMin = new Vector2(0, 1);
			uitransform.anchorMax = new Vector2(0, 1);
			uitransform.pivot = new Vector2(0.5f, 0.5f);
			uitransform.localScale = new Vector2(3, 3);
			L.name = names;
			L.transform.SetParent (sUI.transform, false);

		}
	}

	public void resetPlayerPos(){

		int lives = Player.GetLives();

		if (lives == 1) {
			load ("GameOver");
		}
		else {
			GameObject[] destroyL = GameObject.FindGameObjectsWithTag("Lives");
			lives--;
			Destroy(destroyL[lives]);
			Player.SetLives (lives);
			playerInipos.transform.position = IniPosion;
			seaObj.transform.position = iniSeaLevel;

		}
	}
		
}
