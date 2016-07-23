using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy;
	float sponTime = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sponTime -= Time.deltaTime;
		if (sponTime < 0) {
			Instantiate (enemy, transform.position, Quaternion.identity);
			sponTime = 3.0f;
		}
	}
}
