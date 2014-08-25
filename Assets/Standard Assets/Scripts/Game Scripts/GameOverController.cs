using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	float gameOverTimer;

	void CheckHighscore()
	{
		int _score = PlayerPrefs.GetInt("CurrentScore", 0);
		int _highscore = PlayerPrefs.GetInt("HighScore", 0);
		if (_score > _highscore) {
				PlayerPrefs.SetInt ("HighScore", _score);
		}
	}

	void Start () {
		gameOverTimer = 2.5f;
		CheckHighscore();
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
		gameOverTimer -= Time.deltaTime;
		if (gameOverTimer <= 0.0f) {
			Application.LoadLevel(0);
		}
	}
}
