using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
   
    //public AudioClip shootSound;
    public GameObject hand;
    public GameObject spark;
    private Vector3 direction;

	// Use this for initialization
    IEnumerator destroyBullet(){
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
	void Start () {
        //AudioSource.PlayClipAtPoint(shootSound,transform.position);
        
        hand = GameObject.Find("LeftGun");
        direction = hand.transform.forward;
        StartCoroutine(destroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction*1);
    }
    void OnCollisionEnter(Collision coll){
        //Debug.Log(coll.gameObject.name);
        Instantiate(spark,transform.position,transform.rotation);
        Destroy(this.gameObject);
        if(coll.gameObject.tag == "Enemy")
            coll.gameObject.GetComponent<Enemy>().hitEnemy();
    }
}
