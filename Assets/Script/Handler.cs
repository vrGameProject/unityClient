using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*public class Stage{
	int numOfEnemy;

	public int getNumofEnemy(){
		return numOfEnemy;
	}
}*/
public class Handler : MonoBehaviour {
	private int numOfEnemy = 3;
	private int killPoint;

	private int score=0;
	public Text scoreText;
	public GameObject enemy;
	//public Stage[] stage = new Stage[3];
	//public AudioClip bgm;
	// Use this for initialization

	void Start () {
		//AudioSource.PlayClipAtPoint(bgm,transform.position);
		
		StartCoroutine(spawn());
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator spawn(){
		float posX,posY=-5.0f,posZ = 10;

		while(true){
			Debug.Log("spawn");
			killPoint = numOfEnemy;
			for(int i =0;i<numOfEnemy;i++){
				posX = Random.Range(-10.0f,10.0f);
				Instantiate(enemy,new Vector3(posX,posY,posZ),transform.rotation);
			}
			yield return new WaitUntil(()=>killPoint <= 0);
			numOfEnemy++;
			yield return new WaitForSeconds(3.0f);
		}
	}
	public void killEnemy(int n){
		killPoint--;
		if(n == 1){
			score +=100;
			scoreText.text = score.ToString();
		}
	}
}
