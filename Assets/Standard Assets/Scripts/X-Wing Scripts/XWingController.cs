using UnityEngine;
using System.Collections;

public class XWingController : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject smoke;
	public GameObject explosion;
	public GameObject SmallExlosion;// il GameObject per le esplosioni
	public int vita;
	public int enemyFree;
	public AudioClip XWingSound;
	public float posY= 5.0f;

	void Start () {
		vita = 30;
	}

	void AddScore()
	{
		// prende il punteggio attuale
		int _tempScore = PlayerPrefs.GetInt("CurrentScore");
		
		// aggiungiamo 10 punti e salviamo il nuovo risultato
		_tempScore += 10;
		PlayerPrefs.SetInt("CurrentScore", _tempScore);
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag.Equals("laser"))
		{
			vita-=10;
			Destroy(other.gameObject);
			Instantiate(SmallExlosion, this.transform.position, this.transform.rotation);




			if(vita==0){
				Destroy(other.gameObject);
				Destroy(this.gameObject);
				Instantiate(explosion, this.transform.position, this.transform.rotation);
				Instantiate(explosion, other.transform.position, other.transform.rotation);


				// aumentiamo il punteggio ogni volta che si abbatte un nemico
				AddScore();
			}
		}
		//impatto al suolo
		if (other.gameObject.tag.Equals ("base")) {
			Destroy(this.gameObject);
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			Instantiate(smoke, this.transform.position, this.transform.rotation);

			AddScore();
		}
	}   
	
	// Update is called once per frame
	void Update () {

		if(this.vita==10){ //CADUTA
			this.transform.position += new Vector3(0, this.posY-0.1f, 0);
		}

		this.transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;

		//salvo	
		if (this.transform.position.z < -350.0f) {
			Destroy(this.gameObject);
			addEnimy();
		}
		if(this.transform.position.z < 10.0f){
			audio.PlayOneShot(XWingSound);
		}

		int count = PlayerPrefs.GetInt ("enemyFree");
		//prendo la variabile "enemyFree" poi se count è uguale a 5 termina
		if (count == 5) {
			GameOver();
		}

	}
	//setto la variabile "enemyFree"
	void addEnimy(){
		int _tempfree = PlayerPrefs.GetInt ("enemyFree");
		_tempfree++;
		PlayerPrefs.SetInt ("enemyFree", _tempfree);
	}
	//gameover
	void GameOver()
	{
		Application.LoadLevel(2); // cambio di scena
	}
}
