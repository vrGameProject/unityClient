using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public AudioClip shootSound;
    public SpriteRenderer image;
    public GameObject cube;
	public GameObject head;
    public GameObject leftGun;
	public GameObject Palm;
    //public GameObject rightGun;

    private Vector3 center;
    private float count = 0;
    private float t;
	private Queue bullets = new Queue ();
    // Use this for initialization
    void Start () {
        center = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
		for (int i = 0; i < 100; i++) {
			GameObject tp = Instantiate(cube, leftGun.transform.position, transform.rotation) as GameObject;
			tp.SetActive (false);
			bullets.Enqueue (tp);
		}
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;
       
        t += Time.deltaTime;
		if (Palm.activeSelf && t > 0.08f) {
			leftGun.SetActive (true);
			AudioSource.PlayClipAtPoint (shootSound, transform.position, 0.05f);
			GameObject bullet = bullets.Dequeue () as GameObject;
			bullet.transform.position = leftGun.transform.position;
			bullet.SetActive (true);

			//GameObject tp = Instantiate(cube, leftGun.transform.position, transform.rotation) as GameObject;
			//GameObject tp2 = Instantiate(cube, rightGun.transform.position, transform.rotation) as GameObject;
			//tp.transform.Rotate(head.transform.eulerAngles);
			t = 0;
		} else {
			leftGun.SetActive (false);
		}

        /*if (Physics.Raycast(ray, out hit, 500.0f))
        {
            if (hit.collider.gameObject.CompareTag("box"))
            {
                count += Time.deltaTime;
                image.color = new Color(255, 0, 0);
                if (count > 2)
                {
                    hit.collider.gameObject.SetActive(false);
                    image.color = new Color(255, 255, 255);
                }
            }
            else
            {
                count = 0;
                //image.color = new Color(255, 255, 255);
            }
        }*/
        
	
	}
	public void bulletEnqueue(GameObject bullet){
		bullets.Enqueue (bullet);
		bullet.SetActive (false);
	}
}
