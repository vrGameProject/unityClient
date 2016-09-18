using UnityEngine;
using System.Collections;

public class Pointing : MonoBehaviour {

	public GameObject Gun;
	public GameObject Palm;
	// Use this for initialization
	void Start () {
		Gun.transform.position = Palm.transform.position;
		Gun.transform.rotation = Quaternion.Euler(0,90,90);
		//Gun.transform.forward = Palm.transform.right;
		//Gun.transform.right= Palm.transform.up;
		//Gun.transform.up = Palm.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
