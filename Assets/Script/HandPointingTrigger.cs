using UnityEngine;
using System.Collections;
using Leap;

public class HandPointingTrigger : MonoBehaviour {

    public Transform targetTransform;
    public GUIText guiTxt;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate ()
    {
        HandModel hand_model = GetComponent<HandModel>();
        Hand leap_hand = hand_model.GetLeapHand();

        if (leap_hand == null)
            return;

        targetTransform.position = hand_model.GetPalmPosition();
        targetTransform.forward = hand_model.GetPalmDirection();
        //targetTransform.Rotate(Vector3.right, 90.0f);

        Vector3 direction = hand_model.GetPalmDirection();
        Vector3 position = hand_model.GetPalmPosition();

        guiTxt.text = "direction : ( " +
            targetTransform.forward.x + ", " +
            targetTransform.forward.y + ", " +
            targetTransform.forward.z + ")";
    }
}
