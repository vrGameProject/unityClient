using UnityEngine;
using System.Collections;

public class MagicSpellControl : MonoBehaviour {

	public GameObject MagicIceBall;
	public GameObject FireBeam;
	public GameObject PlasmaLight;
	public GameObject Goong;
	public GvrViewer cardboard;

	float waitTime = 3.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		waitTime -= Time.deltaTime;
		if (waitTime < 0.0f) {
			if (cardboard.Triggered) {
				print ("ICEBALL AAA");

				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+shootSpeed * Time.deltaTime);
				Instantiate (MagicIceBall, transform.position, transform.rotation);
				waitTime = 3.0f;
			} else if (cardboard.Triggered) {
				print ("FIREBEAM SSS");

				Instantiate(FireBeam, transform.position, transform.rotation);
			} else if (cardboard.Triggered) {
				print ("PlasmaLight DDD");

				Instantiate(PlasmaLight, transform.position, transform.rotation);
			} else if (cardboard.Triggered) {
				print ("GOONG FFF");

				Instantiate(Goong, transform.position, transform.rotation);
			}
		}
	}
}
