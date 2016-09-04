using UnityEngine;
using System.Collections;
public class Stage{
	int numOfEnemy;

	public int getNumofEnemy(){
		return numOfEnemy;
	}
}
public class Handler : MonoBehaviour {
	//private int numOfEnemy = 4;

	public GameObject enemy;
	public Stage[] stage = new Stage[3];
	//public AudioClip bgm;
	// Use this for initialization
	void Start () {
		//AudioSource.PlayClipAtPoint(bgm,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}public void spawn(int n){
		float posX,posY=-5.0f;
		for(int i =0;i<stage[n].getNumofEnemy();i++){
			posX = Random.Range(-10.0f,10.0f);
			Instantiate(enemy,new Vector2(posX,posY),transform.rotation);
		}
	}
}
