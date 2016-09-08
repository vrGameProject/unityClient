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
	private int time = 4;

	private int score=0;
	public Text scoreText;
	public Text timeText;
	public Text highScoreText;
	public GameObject enemy;
	public GameObject highScoreBoard;
	public GameObject scoreBoard;
	//public Stage[] stage = new Stage[3];
	//public AudioClip bgm;
	// Use this for initialization

	void Start () {
		//AudioSource.PlayClipAtPoint(bgm,transform.position);
		highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
		
	}
	public void init(){
		
		//Debug.Log(PlayerPrefs.GetInt("highScore"));
		numOfEnemy = 3;
		score = 0;
		scoreText.text = score.ToString();
		StartCoroutine("spawn");
		StartCoroutine("timer");
	}
	// Update is called once per frame
	void Update () {
		if(time < 0){
			if(PlayerPrefs.GetInt("highScore") < score){
				PlayerPrefs.SetInt("highScore",score);
				highScoreText.text = score.ToString();
			}
			StopCoroutine("spawn");
			StopCoroutine("timer");
			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(GameObject enemy in enemys){
				enemy.GetComponent<Enemy>().DestroyThis(1);
			}
			StartBtn.is_started = false;
			highScoreBoard.SetActive(true);
			scoreBoard.SetActive(false);
			time = 60;
		}
	}
	IEnumerator timer(){
		time = 60;
		while(time >= 0){
			timeText.text = time.ToString();
			time--;
			yield return new WaitForSeconds(1.0f);
		}
	}
	IEnumerator spawn(){
		float posX,posY=-5.0f,posZ = 10;

		while(true){
			Debug.Log("spawn");
			yield return new WaitForSeconds(3.0f);
			killPoint = numOfEnemy;
			for(int i =0;i<numOfEnemy;i++){
				posX = Random.Range(-10.0f,10.0f);
				Instantiate(enemy,new Vector3(posX,posY,posZ),transform.rotation);
			}
			yield return new WaitUntil(()=>killPoint <= 0);
			time += numOfEnemy*2;
			numOfEnemy++;
			
		}
	}
	public void killEnemy(int n){
		killPoint--;
		if(n == 1){
			score +=100;
			scoreText.text = score.ToString();
		}
	}
	/*public void addTime(int n){
		time += n;
	}*/
}
