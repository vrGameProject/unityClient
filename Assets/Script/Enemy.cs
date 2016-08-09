using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private bool B_pattern1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!B_pattern1 && transform.position.y < 1.0f){
			B_pattern1 = true;
			StartCoroutine(pattern1());
		}
	}
	IEnumerator pattern1(){
		GetComponent<Rigidbody>().AddForce(Vector3.up*10,ForceMode.Impulse);
		yield return new WaitForSeconds(0.5f);
		B_pattern1 = false;
	}
}
