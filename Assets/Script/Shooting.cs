using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public SpriteRenderer image;

    private Vector3 center;
    private float count = 0;
	// Use this for initialization
	void Start () {
        center = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 500.0f))
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
                image.color = new Color(255, 255, 255);
            }
        }
        
	
	}
}
