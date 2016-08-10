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
			direction = Camera.main.transform.forward * 0.5f;
			transform.position = Camera.main.transform.position;
			transform.Translate (direction);
		}
	}
}
