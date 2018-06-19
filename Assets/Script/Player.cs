using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {


	public static void UnlockedLevel(){
		
		Scene stmp = SceneManager.GetActiveScene ();
		Debug.Log (stmp.name);
		string s = stmp.name;
		PlayerPrefs.SetInt (s, 1);

	}
	public static bool LevelInfo(string levels){
		return PlayerPrefs.HasKey(levels);
	}
	public static void SetWeight(float w){
		PlayerPrefs.SetFloat ("weight", w);
	}
	public static float GetWeight(){
		return PlayerPrefs.GetFloat ("weight");
	}
	public static void SetFart(float f){
		PlayerPrefs.SetFloat ("Fart", f);
	}
	public static float GetFart(){
		return PlayerPrefs.GetFloat ("Fart");
	}
	public static void SetGGas(float g){
		PlayerPrefs.SetFloat ("GGas", g);
	}
	public static float GetGGas(){
		return PlayerPrefs.GetFloat ("GGas");
	}
	public static void SetLives(int l){
		PlayerPrefs.SetInt ("Lives", l);
	}
	public static int GetLives(){
		return PlayerPrefs.GetInt ("Lives");
	}

}
