using UnityEngine;
using System.Collections;
using Leap;

// 
public class PalmFrontTrigger : MonoBehaviour {

    // Ratio of the length of the proximal bone of the thumb that will trigger a pinch.
    public float facingTriggerAngle = 45.0f;
    private Vector3 criteriaAngle = new Vector3(280, 0, 0);

    public Transform parent_transform;
    public GUIText guiTxt;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void FixedUpdate ()
    {
        HandModel hand_model = GetComponent<HandModel>();
        Hand leap_hand = hand_model.GetLeapHand();

        if (leap_hand == null)
            return;

        Vector3 diff;
        Vector3 palm_rotation;
        
        palm_rotation = hand_model.GetPalmRotation().eulerAngles - parent_transform.eulerAngles;

        diff = palm_rotation - criteriaAngle;

        diff.x = Mathf.Abs(diff.x);
        diff.y = Mathf.Abs(diff.y);
        diff.z = Mathf.Abs(diff.z);

        if (Mathf.Abs(diff.x) < facingTriggerAngle && Mathf.Abs(diff.y) < facingTriggerAngle)
            guiTxt.text = "facing";
        else
            guiTxt.text = "not facing";
    }
}
