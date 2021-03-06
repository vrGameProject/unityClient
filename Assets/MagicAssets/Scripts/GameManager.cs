﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager singletonInstance = null;

	public Button restartButton;

	public Text scoreText;
	private int score;
	public static bool scoreInitLock = true;

	public int totalTime = 60;
	public Text timeText;
    private int time;
	private GameObject[] gameObjects1;
	private GameObject[] gameObjects2;
	private GameObject[] gameObjects3;

	private bool isRestart = false;

	void Awake () {
		singletonInstance = this;
	}
    
	// Use this for initialization
	void Start () {
		score = 0;
		time = totalTime;
		StartCoroutine (timer());
	}

	// Update is called once per frame
	void Update () {

		if (time==0 && (Input.GetKeyDown (KeyCode.R) || isRestart)) {
			EnemySpawn.spawnLock = false;
			scoreInitLock = false;
			time = totalTime;
			StartCoroutine (timer());
			isRestart = false;
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
		gameObjects1 = GameObject.FindGameObjectsWithTag ("Magic_Enemy_Fire");
		gameObjects2 = GameObject.FindGameObjectsWithTag ("Magic_Enemy_Ice");
		gameObjects3 = GameObject.FindGameObjectsWithTag ("Magic_Enemy_Light");

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

	public void Restart() {
		this.isRestart = true;
    }

    public bool isPause()
    {
        return time == 0;
    }
}
