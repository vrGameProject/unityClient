using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public static bool spawnLock = false;

	float sponTime = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (spawnLock == false) {
			sponTime -= Time.deltaTime;
			if (sponTime < 0) {
				int random = Random.Range (1, 4);
				print ("random" + random);

				switch (random) {
				case 1:
					Instantiate (enemy1, transform.position, Quaternion.identity);
					break;
				case 2:
					Instantiate (enemy2, transform.position, Quaternion.identity);
					break;
				case 3:
					Instantiate (enemy3, transform.position, Quaternion.identity);
					break;
				}

				sponTime = 3.0f;
			}
		}
	}
}
