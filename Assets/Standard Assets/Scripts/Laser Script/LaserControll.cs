using UnityEngine;
using System.Collections;

public class LaserControll : MonoBehaviour {

	// Use this for initialization
	public float velocitaLaser;
	public Rigidbody LaserSpara;
	public Transform Spawn;
	public float aliveTimer = 0.0f;
	Rigidbody laserS;
	public Texture crosshair;
	public AudioClip suono;

	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		aliveTimer += Time.deltaTime;
		if(Input.GetMouseButtonDown(0)){
			Scocca();
		}
		//per distruggere i laser
		//if (aliveTimer > 10.0f) {
			//Distruggi();
		//}
	}
	//mirino
	void OnGUI(){
		GUI.DrawTexture (new Rect(Screen.width/2-55, Screen.height/2-50, 100, 100), crosshair);
	}

	void Scocca(){
		laserS = Instantiate (LaserSpara, Spawn.position, Spawn.rotation) as Rigidbody;
		laserS.AddForce (transform.forward * velocitaLaser);
		audio.PlayOneShot (suono);
	}

}
