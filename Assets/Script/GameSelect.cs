using UnityEngine;
using System.Collections;

public class GameSelect : MonoBehaviour {

	private Vector3 center;
	private string selectedGameBtn;
	// Use this for initialization
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
		}

		//손 인식 되면 게임 시작.
	}
}
