using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSelect : MonoBehaviour {

	private Vector3 center;
	private string selectedGameBtn;
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
			print(selectedGameBtn);
		}

		switch(selectedGameBtn){
			case "Btn1": resetBtn(); btns[0].GetComponent<Image>().color = new Color(255,255,255); imgs[0].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn2": resetBtn(); btns[1].GetComponent<Image>().color = new Color(255,255,255); imgs[1].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn3": resetBtn(); btns[2].GetComponent<Image>().color = new Color(255,255,255); imgs[2].GetComponent<Image>().color = new Color(240,255,244);break;
			case "Btn4": resetBtn(); btns[3].GetComponent<Image>().color = new Color(255,255,255); imgs[3].GetComponent<Image>().color = new Color(240,255,244);break;
		}
		//손 인식 되면 게임 시작.
	}
	void resetBtn(){
		foreach(GameObject img in imgs){
			img.GetComponent<Image>().color = new Color(255,0.6f,255);
		}
		foreach (GameObject key in btns){
			key.GetComponent<Image>().color = new Color(255,0,238);
		}
	}
}
