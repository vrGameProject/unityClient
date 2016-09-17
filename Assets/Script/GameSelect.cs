using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSelect : MonoBehaviour {

	private Vector3 center;
	private string selectedGameBtn;
	private string sceneName;
	public Image loading;
	// Use this for initialization
	public GameObject[] btns = new GameObject[4];
	public GameObject[] imgs = new GameObject[4];
	void Start () {
		center = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(center);
		
        RaycastHit hit;

		if(Physics.Raycast(ray,out hit,10000f))
		{
			selectedGameBtn = hit.collider.name;
			delayForStart();
			print(selectedGameBtn);
		}else{
			selectedGameBtn = "";
			loading.fillAmount = 0;
		}

		switch(selectedGameBtn){
			case "Btn1": sceneName = "Shooting";resetBtn(); btns[0].GetComponent<Image>().color = new Color(255,255,255); imgs[0].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn2": sceneName = "magicMain";resetBtn(); btns[1].GetComponent<Image>().color = new Color(255,255,255); imgs[1].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn3": resetBtn(); btns[2].GetComponent<Image>().color = new Color(255,255,255); imgs[2].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn4": resetBtn(); btns[3].GetComponent<Image>().color = new Color(255,255,255); imgs[3].GetComponent<Image>().color = new Color(240,255,244);break;
			default : resetBtn();break;
		}
		//손 인식 되면 게임 시작.
	}
	void delayForStart(){
		loading.fillAmount +=1.0f/3*Time.deltaTime;
		if(loading.fillAmount == 1){
			SceneManager.LoadScene(sceneName);
		}
	}
	void resetBtn(){
		foreach(GameObject img in imgs){
			img.GetComponent<Image>().color = new Color(255,0.6f,255);
		}
		foreach (GameObject key in btns){
			key.GetComponent<Image>().color = new Color(0.5f,0.55f,238);
		}
	}
}
