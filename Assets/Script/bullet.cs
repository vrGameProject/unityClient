using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public GameObject hand;
    public GameObject spark;
    private Vector3 direction;

	// Use this for initialization
    IEnumerator destroyBullet(){
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
	void Start () {
        hand = GameObject.Find("LeftGun");
        direction = hand.transform.forward;
        StartCoroutine(destroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction*1);
    }
    void OnCollisionEnter(Collision coll){
        Debug.Log(coll.gameObject.name);
        Instantiate(spark,coll.gameObject.transform.position,transform.rotation);
        Destroy(this.gameObject);
        coll.gameObject.GetComponent<Enemy>().hitEnemy();
    }
}
