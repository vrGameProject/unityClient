using UnityEngine;
using System.Collections;

public class MagicSpellControl : MonoBehaviour {

	public GameObject MagicIceBall;
	public GameObject FireBeam;
	public GameObject PlasmaLight;
	public GameObject Goong;
	public GvrViewer cardboard;

	static float TIME_VAL = 1.0f;
	float waitTime = TIME_VAL;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		waitTime -= Time.deltaTime;
		if (waitTime < 0.0f) {
			if (Input.GetKeyDown(KeyCode.A)) {
				//print ("ICEBALL AAA");

				//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+shootSpeed * Time.deltaTime);
				Instantiate (MagicIceBall, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			} else if (Input.GetKeyDown(KeyCode.S)) {
				//print ("FIREBEAM SSS");

				Instantiate(FireBeam, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			} else if (Input.GetKeyDown(KeyCode.D)) {
				//print ("PlasmaLight DDD");

				Instantiate(PlasmaLight, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			} else if (Input.GetKeyDown(KeyCode.F)) {
				//print ("GOONG FFF");

				Instantiate(Goong, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			}
		}
	}
}
