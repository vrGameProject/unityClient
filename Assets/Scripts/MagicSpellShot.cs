using UnityEngine;
using System.Collections;

public class MagicSpellShot : MonoBehaviour {

	public GameObject effect;
	private GameObject deadEffect;
	private Vector3 direction;
	private float speed = 0.5f;

	private Score score;
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
			score = gameControllerObject.GetComponent <Score>();
		}
		if (score == null)
		{
			Debug.Log ("Cannot find 'Score' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 3);
		transform.Translate (direction);
	}

	void onTriggerEnter(Collider col){
		if (col.tag == "Enemy") {
			Destroy (gameObject,0.1f);
		}
	}
		
	void OnCollisionEnter(Collision col){
		//print ("꿍해써");
		Destroy (gameObject,0.05f);

		if ((gameObject.tag == "MagicIce")&&(col.collider.tag == "EnemyIce")) {
			print ("Ice 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			score.AddScore (scoreValue);
		}

		if ((gameObject.tag == "MagicFire")&&(col.collider.tag == "EnemyFire")) {
			print ("Fire 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			score.AddScore (scoreValue);
		}

		if ((gameObject.tag == "MagicLight")&&(col.collider.tag == "EnemyLight")) {
			print ("Light 꿍");
			deadEffect = Instantiate (effect, col.collider.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.collider.gameObject,2.0f);
			Destroy (deadEffect, 2.0f);

			score.AddScore (scoreValue);
		}
	}
}
