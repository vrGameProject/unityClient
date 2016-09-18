using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public GameObject player;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			float y = 0.0f;
			direction = Camera.main.transform.forward * 0.3f;
			direction.y = y;
			//transform.position = Camera.main.transform.position;
			transform.Translate (direction);
		}
	}
}
