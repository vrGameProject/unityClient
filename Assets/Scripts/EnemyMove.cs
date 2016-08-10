using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public GameObject enemy;
	Transform myTrans;
	float moveTime = 2.0f;

	float randomX = 0.01f;
	float randomZ = 0.01f;

	bool updateLock = false;
		
	// Use this for initialization
	void Start () {
		myTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateLock == false) {
			
			if (moveTime == 2.0f) {
				randomX = Random.Range (-0.05f, 0.05f);
				randomZ = Random.Range (-0.05f, 0.05f);
			}

			moveTime -= Time.deltaTime;

			//print ("time: " + moveTime);
			//print ("rx: " + randomX);
			//print ("rz: " + randomZ);

			myTrans.position = new Vector3 (myTrans.position.x + randomX, myTrans.transform.position.y, myTrans.position.z + randomZ);

			if (moveTime <= 0.0f) {
				moveTime = 2.0f;
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if ((col.collider.tag == "MagicIce")&&(gameObject.tag == "EnemyIce")) {
			updateLock = true;
			print ("Ice 꿍꿍");
		}

		if ((col.collider.tag == "MagicFire")&&(gameObject.tag == "EnemyFire")) {
			updateLock = true;
			print ("Fire 꿍꿍");
		}

		if ((col.collider.tag == "MagicLight")&&(gameObject.tag == "EnemyLight")) {
			updateLock = true;
			print ("Light 꿍꿍");
		}
	}
}
