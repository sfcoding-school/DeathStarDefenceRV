using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public GameObject enimy;
	public GameObject laser;
	public GUIText score;
	public GUIText freeE;
	public AudioClip explosion;
	
	float spawnTimer;
	float shootTimer;

	void Start () {
		spawnTimer = 5.0f;
		Screen.showCursor = false;
		PlayerPrefs.SetInt("CurrentScore", 0); // azzeriamo il contatore
		PlayerPrefs.SetInt ("enemyFree", 0); //arreriamo il contatore dei nemici
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag.Equals ("enimy")) {
			audio.PlayOneShot(explosion);
		}
	}
	
	// Update is called once per frame
	void Update () {


		spawnTimer -= Time.deltaTime;
		shootTimer -= Time.deltaTime;

		//verifichiamo che siano passati 5 secondi
		if(spawnTimer <= 0.0f){
			//se sono passati 5 sec generiamo un nuovo nemico
			GameObject instance = (GameObject) Instantiate(enimy, new Vector3(Random.Range(-55.5f,55.5f), Random.Range(18.0f,20.0f), 150.0f),transform.rotation);
			
			//resettiamo il timer (tempo di respawn)
			spawnTimer = 3.5f;
		}


		//scriviamo il punteggio sul contatore
		score.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
		freeE.text = PlayerPrefs.GetInt ("enemyFree", 0).ToString ();

			}
	}

