using UnityEngine;
using System.Collections;

public class MagicSpellShot : MonoBehaviour {

	public GameObject effect;
	private GameObject deadEffect;
	private Vector3 direction;
	private float speed = 0.5f;

	private GameManager gameManager_;
	public int scoreValue;

	// Use this for initialization
	void Start () {
		direction = Camera.main.transform.forward * speed;
		transform.position = Camera.main.transform.position;
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f, +transform.position.z);

		scoreValue = 1;
		GameObject gameControllerObject = GameObject.FindWithTag ("Score");
		if (gameControllerObject != null)
		{
            gameManager_ = GameManager.singletonInstance;
		}
		if (gameManager_ == null)
		{
			Debug.Log ("Cannot find 'Score' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 3);
		transform.Translate (direction);

		if (GameManager.scoreInitLock == false) {
			gameManager_.initScore ();
			GameManager.scoreInitLock = true;
		}
	}
		
	void OnCollisionEnter(Collision col){
		//print ("꿍해써");
		if ((gameObject.tag == "Magic_Ice")&&(col.collider.tag == "Magic_Enemy_Ice")) {
			print ("Ice 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			gameManager_.AddScore (scoreValue);
		}

		if ((gameObject.tag == "Magic_Fire")&&(col.collider.tag == "Magic_Enemy_Fire")) {
			print ("Fire 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			gameManager_.AddScore (scoreValue);
		}

		if ((gameObject.tag == "Magic_Light")&&(col.collider.tag == "Magic_Enemy_Light")) {
			print ("Light 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			gameManager_.AddScore (scoreValue);
        }
        Destroy(gameObject, 0.05f);
    }
}
