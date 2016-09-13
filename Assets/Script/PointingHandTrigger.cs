using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class PointingHandTrigger : MonoBehaviour {

	public GameObject gun;
	public Text guiTxt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		HandModel hand_model = GetComponent<HandModel>();
    	Hand leap_hand = hand_model.GetLeapHand();

    	if (leap_hand == null)
      		return;
			
		guiTxt.text = "1";

/*
		if (gun == null)
			return;

		guiTxt.text = "@";

		guiTxt.text = "3";
		Vector3 direction = hand_model.GetPalmDirection();
		Vector3 position = hand_model.GetPalmPosition();
		
		gun.transform.position = position;
		gun.transform.forward = hand_model.palm.right;
		
		guiTxt.text = "forward : (" + 
			gun.transform.forward.x + ", " +
			gun.transform.forward.y + ", " +
			gun.transform.forward.z + ")";
*/
	}
}
