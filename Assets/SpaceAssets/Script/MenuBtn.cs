using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll){
		Debug.Log(coll.gameObject.tag);
		if(coll.gameObject.tag == "Bullet"){
			SceneManager.LoadScene ("GameSelect");
		}
	}
}
