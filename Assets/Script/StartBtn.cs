using UnityEngine;
using System.Collections;

public class StartBtn : MonoBehaviour {
	public GameObject highScoreBoard;
	public GameObject scoreBoard;
	static public bool is_started;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll){
		Debug.Log(coll.gameObject.tag);
		if(!is_started && coll.gameObject.tag == "Bullet"){
			is_started = true;
			GameObject.Find("Handler").GetComponent<Handler>().init();
			scoreBoard.SetActive(true);
			highScoreBoard.SetActive(false);
			
		}
	}
	public void Gameover(){
		Debug.Log("Gameover");
		highScoreBoard.SetActive(true);
		scoreBoard.SetActive(false);
	}
}
