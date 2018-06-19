using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
public class MenuGM : MonoBehaviour {
	public GameObject MenuPanel;
	public GameObject LevelPanel;
	public GameObject StarterPanel;// use it to intruduce our game story like animation.
	public Button ButtonPrefab;

	public InputField Playerweight;
	public string []levels;

	private string Cname;
	// Use this for initialization
	void Awake () {
		SetLevel ();//setlevel first
		switchPanel ("menu");
	
		//InvokeRepeating ("StarterPanelControl", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	public void switchPanel(string name){
		MenuPanel.SetActive (false);
		LevelPanel.SetActive (false);
		StarterPanel.SetActive (false);
		switch (name) {
		case "starter":
			StarterPanel.SetActive (true);
			StartButtonLis ();
			break;
		case "menu":
			MenuPanel.SetActive (true);
			break;
		case "level":
			LevelPanel.SetActive (true);
			break;
		default:
			Debug.Log ("no match panel");
			break;
		}
	
	}
	//if we need the ainmation in the begin
	/*void StarterPanelControl(){
		timer -= 1;
		if (timer == 0) {
			switchPanel ("menu");
			CancelInvoke("StarterPanelControl");
		}
	}*/
	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
	public void exit(){
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}
	void SetLevel(){
		//LevelPanel.SetActive (true);

		for (int i = 0; i < levels.Length; i++) {
			string levelnames = levels [i];
			Button LevelB = Instantiate (ButtonPrefab, new Vector3 (0, i * 20, 0), Quaternion.identity);
			LevelB.transform.position = new Vector3 (0, -i*30, 0);
			LevelB.name = "Level" + levelnames;
			LevelB.transform.SetParent (LevelPanel.transform, false);
			LevelB.onClick.RemoveAllListeners ();
			LevelB.onClick.AddListener (() => switchPanel ("starter"));


			//dynamically create level button
			Text LBscript = LevelB.GetComponentInChildren<Text>();
			LBscript.text = "Level "+levelnames;
			//control active level
			if (Player.LevelInfo (LevelB.name))
				LevelB.interactable = true;
			else
				LevelB.interactable = false;

		}

	
	
	}
	    void StartButtonLis(){
	
		Cname = EventSystem.current.currentSelectedGameObject.name;

		//Debug.Log (name);
	}
	public void Onclick(){
		string tmp = Playerweight.text;
		float weight = Single.Parse (tmp);
		Player.SetWeight (weight);
		if (Cname == "NewGame")
			LoadScene ("Level1");
		 else 
			LoadScene (Cname);
			
	
	}
}
