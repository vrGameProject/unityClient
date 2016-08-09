using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject cam;
    private Vector3 direction;

	// Use this for initialization
    IEnumerator destroyBullet(){
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
	void Start () {
        direction = Camera.main.transform.forward;
        StartCoroutine(destroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction*1);
       
    }
}
