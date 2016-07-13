using UnityEngine;
using System.Collections;

public class MagicSpellControl : MonoBehaviour {

	public GameObject MagicIceBall;
	public GvrViewer cardboard;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cardboard.Triggered) {
			print ("triggered");

			//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+shootSpeed * Time.deltaTime);
			Instantiate(MagicIceBall, transform.position, transform.rotation);

		}
	}
}
