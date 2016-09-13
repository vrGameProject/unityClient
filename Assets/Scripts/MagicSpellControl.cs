using UnityEngine;
using System.Collections;

public class MagicSpellControl : MonoBehaviour {
	private const int MAGIC_ICEBALL = 1;
	private const int MAGIC_FIREBALL = 2;
	private const int MAGIC_LIGHTBALL = 3;

	public static MagicSpellControl singletonInstance = null;

	public GameObject MagicIceBall;
	public GameObject FireBeam;
	public GameObject PlasmaLight;
	public GameObject EffectSound;
	public GvrViewer cardboard;

	static float TIME_VAL = 1.0f;
	float waitTime = TIME_VAL;

	int magic = 0;

	void Awake () {
		singletonInstance = this;
	}

	// Use this for initialization
	void Start () {
		magic = 0;
	}

	// Update is called once per frame
	void Update () {
		waitTime -= Time.deltaTime;
		if (waitTime < 0.0f) {
			if (Input.GetKeyDown(KeyCode.A) || magic == MAGIC_ICEBALL) {
				//print ("ICEBALL AAA");

				Instantiate (EffectSound);
				Instantiate (MagicIceBall, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			} else if (Input.GetKeyDown(KeyCode.S) || magic == MAGIC_FIREBALL) {
				//print ("FIREBEAM SSS");

				Instantiate (EffectSound);
				Instantiate(FireBeam, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			} else if (Input.GetKeyDown(KeyCode.D) || magic == MAGIC_LIGHTBALL) {
				//print ("PlasmaLight DDD");

				Instantiate (EffectSound);
				Instantiate(PlasmaLight, transform.position, transform.rotation);
				waitTime = TIME_VAL;
			}

			//Instantiate (MagicIceBall, transform.position, transform.rotation);
			//waitTime = TIME_VAL;
		}
	}

	public void setMaigc(int magic) {
		this.magic = magic;
	}
}
