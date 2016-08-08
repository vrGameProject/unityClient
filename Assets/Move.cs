using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float mv = Input.GetAxis("Vertical");
        float mh = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * mv);
        transform.Translate(Vector3.right * Time.deltaTime * speed * mh);
    }
}
