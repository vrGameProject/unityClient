using UnityEngine;
using System.Collections;

public class MagicSpellShot : MonoBehaviour {

	public GameObject camera;
	Vector3 startPosition = new Vector3(0.0f, 0.5f, 0.0f);
	float shootSpeed = 12.0f;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		direction = Camera.main.transform.forward * 0.5f;
		transform.position = Camera.main.transform.position;
		//transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction);
		//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + shootSpeed * Time.deltaTime);
	}
}
