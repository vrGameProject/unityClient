using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp = 10;
	public GameObject explosion;
	private GameObject player;
	private bool hitState;
	private bool B_pattern1;
	private bool is_spawned;
	private float posX,posY,posZ;

	private float r;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(upPattern());
		player = GameObject.Find("Player");
		r = Random.Range(4.0f,7.0f);
		posY = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if(is_spawned){
			transform.position = new Vector3(transform.position.x,transform.position.y+posY,transform.position.z);
		}else{
			
			transform.position = new Vector3(transform.position.x+posX,transform.position.y+posY,transform.position.z+posZ);
		}
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
	IEnumerator upPattern(){
		yield return new WaitUntil(()=>transform.position.y > r);
		is_spawned = false;
		StartCoroutine(pattern1());
	}
	IEnumerator pattern1(){
		float delay;
		while(true){
			posX = Random.Range(-0.05f,0.05f);
			posY = Random.Range(-0.05f,0.05f);
			posZ = Random.Range(-0.05f,0.05f);
			delay = Random.Range(2.0f,3.0f);
			if(transform.position.y < 2)
				posY = 0.1f;
			if(transform.position.y>20.0f)
				posY = -0.1f;
			if(transform.position.x < -20.0f)
				posX = 0.1f;
			if(transform.position.x>20.0f)
				posX = -0.1f;
			if(transform.position.z < 5.0f)
				posZ = 0.1f;
			if(transform.position.z >10.0f)
				posZ = -0.1f;
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
			GameObject.Find("Handler").GetComponent<Handler>().killEnemy();
			Destroy(this.gameObject);
		}
	}
}
