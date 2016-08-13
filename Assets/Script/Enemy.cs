using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp = 10;
	public GameObject explosion;
	private GameObject player;
	private bool hitState;
	private bool B_pattern1;
	private float posX,posY,posZ;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(pattern1());
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -1)
			posY = 0.05f;
		else if(transform.position.y>20.0f)
			posY = -0.05f;
		else if(transform.position.x < -20.0f)
			posX = 0.05f;
		else if(transform.position.x>20.0f)
			posX = -0.05f;
		else if(transform.position.z < 5.0f)
			posZ = 0.05f;
		else if(transform.position.z >20.0f)
			posZ = -0.05f;
		transform.position = new Vector3(transform.position.x+posX,transform.position.y+posY,transform.position.z+posZ);
		/*if(!B_pattern1 && transform.position.y < 1.0f){
			B_pattern1 = true;
			StartCoroutine(pattern1());
		}*/
		if(!hitState){
			Debug.Log(player.transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.localPosition - transform.localPosition), 0.2f);
			//Quaternion dir = Quaternion.LookRotation(player.transform.position); //바라볼 벡터
			//transform.rotation = Quaternion.Slerp(transform.rotation, dir, 0.1f);
		}
	}
	IEnumerator pattern1(){
		float delay;
		while(true){
			posX = Random.Range(-0.05f,0.05f);
			posY = Random.Range(-0.05f,0.05f);
			posZ = Random.Range(-0.05f,0.05f);
			delay = Random.Range(2.0f,3.0f);
			//posX += Mathf.Clamp (transform.position.x,-0.20f, 0.20f);
			//posY += Mathf.Clamp (transform.position.y,-0.01f, 0.20f);
			//posZ += Mathf.Clamp (transform.position.z,0.05f, 0.20f);
			yield return new WaitForSeconds(delay);
			posX = posY = posZ = 0;
			yield return new WaitForSeconds(2.0f);
		}
	}
	IEnumerator onHitState(){
		hitState = true;
		yield return new WaitForSeconds(1.0f);
		hitState = false;
	}
	public void hitEnemy(){
		hp--;
		StartCoroutine(onHitState());
		if(hp<0){
			Instantiate(explosion,transform.position,transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
