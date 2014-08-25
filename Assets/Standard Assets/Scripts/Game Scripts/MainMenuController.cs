using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	public GUIStyle personal;
	public GUIStyle personal1;
	public GUIStyle personal2;
	public string punti, risp;

	void Start () {
		Screen.showCursor = true;
		risp = "";
		punti=PlayerPrefs.GetInt("HighScore",0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect(Screen.width/2 - 500, Screen.height/2 - 250, 300, 300));
		GUI.Box (new Rect (-15,-20,300,300), "", personal1);
		if(GUI.Button (new Rect (30,40,110,30), "PLAY", personal)){
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(30,80,110,30), "RECORD", personal)){
			risp=punti;

		}
		if(GUI.Button(new Rect(30,120,110,30), "QUIT", personal)){
			Application.Quit();
		}


		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect(Screen.width/2 - 300, Screen.height/2 - 150, 300, 300));
		GUI.Box (new Rect (-15,-20,50,50), "", personal2);
		GUILayout.Label (risp, GUILayout.Width(150), GUILayout.Height(150));
		GUILayout.EndArea ();
	}
	
}
