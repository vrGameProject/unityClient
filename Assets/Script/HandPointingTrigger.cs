using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class HandPointingTrigger : MonoBehaviour {

    public GameObject head_;
    public GameObject gun_;

    public Transform gun_transform;
    public Transform palm_transform;

    public Text txt;

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

        gun_.transform.position.Set(0, 0, 0);
        
        gun_.transform.position.Set(head_.transform.position.x, head_.transform.position.y, head_.transform.position.z);

        txt.text = "palm pos : " +
            palm_transform.position.x + ", " +
            palm_transform.position.y + ", " +
            palm_transform.position.z;

        gun_transform = palm_transform;

        txt.text += "\ngun pos : " +
            gun_transform.position.x + ", " +
            gun_transform.position.y + ", " +
            gun_transform.position.z;

        if (leap_hand.PalmPosition != null)
            txt.text += "\nFuck You too";

        Vector pos = leap_hand.PalmPosition;

        txt.text +=
            "\n pos : (\n" +
            pos.x + ", " +
            pos.y + ", " +
            pos.z;

        gun_.transform.position = palm_transform.position;


        txt.text +=
            "\n pos : (\n" +
            pos.x + ", " +
            pos.y + ", " +
            pos.z;

        gun_.transform.right = head_.transform.forward * -1;
    }
}
