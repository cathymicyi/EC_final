using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//including all the UI msg update
public class MainGM : MonoBehaviour {
	public static MainGM gm;
	public Slider GGSBar;
	public Slider FartBar;
	public Image LivePref;
	public Canvas sUI;


	// Use this for initialization
	void Awake () {
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
		Player.SetFart (100.0f);
		Player.SetGGas (10.0f);
		Player.SetLives (3);
		float GGs = Player.GetGGas();
		GGSBar.value = GGs;
		LivesGenerates ();
	}
	void UpdateScreenUI(){
		float currentGGS = Player.GetGGas();
		GGSBar.value = currentGGS;

		float currentF = Player.GetFart ();
		FartBar.value = currentF;



		if(currentGGS >= 15.0f )//max greenhouse the die
		{   int currentL = Player.GetLives();
			
			if(currentL != 0)
			{
				GameObject[] destroyL = GameObject.FindGameObjectsWithTag("Lives");
				currentL--;
				Destroy(destroyL[currentL]);
				Player.SetLives(currentL);
				resetPlayerPos();
			}
			else
			{
				/*To Do if run out all the lives(load menu?)
							*/
			}

		}

	}
	void LivesGenerates(){
		int totalLives = Player.GetLives ();
		for (int i = 0; i < totalLives; i++) {
			string names = "Live" + i;
			Image L = Instantiate (LivePref, new Vector3 (-310 + (i * 3), -120, 0), Quaternion.identity);
			L.transform.position = new Vector3 (-310 + (i * 10), -120, 0);
			L.name = names;
			L.transform.SetParent (sUI.transform, false);

		}
	}

	void resetPlayerPos(){
		Player.SetFart (100.0f);
		Player.SetGGas (10.0f);
		//To Do:
	/**if player die, reset to origin pos and reset greenhouse gas to default value, farting poweraswell**/	
	}
		


}
