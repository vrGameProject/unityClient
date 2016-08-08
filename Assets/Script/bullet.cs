using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject cam;
    private Vector3 direction;
	// Use this for initialization
	void Start () {
        direction = cam.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction*1);
       
    }
}
