using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Text scoreText;
	private int score;
	public static bool scoreInitLock = true;

	private static int totalTime = 10;
	public Text timeText;
	private int time = totalTime;
	private GameObject[] gameObjects1;
	private GameObject[] gameObjects2;
	private GameObject[] gameObjects3;

	// Use this for initialization
	void Start () {
		score = 0;
		time = totalTime;
		StartCoroutine (timer());
	}

	// Update is called once per frame
	void Update () {
		if (time==0 && Input.GetKeyDown (KeyCode.R)) {
			EnemySpawn.spawnLock = false;
			scoreInitLock = false;
			time = totalTime;
			StartCoroutine (timer());
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void initScore()
	{
		score = 0;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	IEnumerator timer(){
		for (int i = 0; i < totalTime; i++) {
			time -= 1;
			timeText.text = "Time: " + time;

			if (time == 0) {
				print ("gameover");
				DestroyAllObjects ();
			}

			yield return new WaitForSeconds (1.0f);
		}
	}

	void DestroyAllObjects()
	{
		gameObjects1 = GameObject.FindGameObjectsWithTag ("EnemyFire");
		gameObjects2 = GameObject.FindGameObjectsWithTag ("EnemyIce");
		gameObjects3 = GameObject.FindGameObjectsWithTag ("EnemyLight");

		for(int i = 0 ; i < gameObjects1.Length ; i ++)
		{
			Destroy(gameObjects1[i]);
		}

		for(int i = 0 ; i < gameObjects2.Length ; i ++)
		{
			Destroy(gameObjects2[i]);
		}

		for(int i = 0 ; i < gameObjects3.Length ; i ++)
		{
			Destroy(gameObjects3[i]);
		}

		EnemySpawn.spawnLock = true;
	}
}
