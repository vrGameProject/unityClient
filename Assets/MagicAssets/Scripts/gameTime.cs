using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameTime : MonoBehaviour {

	private static int totalTime = 60;
	public Text timeText;
	private int time = totalTime;
	private GameObject[] gameObjects1;
	private GameObject[] gameObjects2;
	private GameObject[] gameObjects3;
	//private gameTime gameTimeText;

	// Use this for initialization
	void Start () {
		time = totalTime;
		StartCoroutine (timer());
		//timeText = GetComponent<Text> ();
		//timeText.text = "??";
	}
	
	// Update is called once per frame
	void Update () {
		//timeText.text = "??";
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
