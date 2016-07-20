using UnityEngine;
using System.Collections;

public class MagicSpellShot : MonoBehaviour {
	
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		direction = Camera.main.transform.forward * 0.5f;
		transform.position = Camera.main.transform.position;
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f, +transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 3);
		transform.Translate (direction);
	}
	/*
	void onTriggerEnter(Collider col){
		if (col.tag == "Enemy") {
			Destroy (gameObject,0.1f);
		}
	}
	*/

	void OnCollisionEnter(Collision col){
		print ("꿍해써");
		Destroy (gameObject,0.05f);

		if (col.collider.tag == "Enemy") {
			print ("꿍해따니까");
			Destroy (col.collider.gameObject);
		}

		if (col.collider.tag == "Enemy2") {
			print ("나두꿍해써");
		}
	}
}
