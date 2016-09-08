using UnityEngine;
using System.Collections;
using Leap;

public class HandElementsLogger : MonoBehaviour
{

    public Transform handParentTransform;
    public GUIText guiTxt;

    private Vector3 palm_position;
    private Vector3 palm_rotation;

    private Vector[] finger_positions;
    private Vector3 thumb_position;
    private Vector3 index_position;
    private Vector3 middle_position;
    private Vector3 ring_position;
    private Vector3 pinky_position;

    // Use this for initialization
    void Start()
    {
        finger_positions = new Vector[5];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        HandModel hand_model = GetComponent<HandModel>();
        Hand leap_hand = hand_model.GetLeapHand();

        palm_position = hand_model.GetPalmPosition() - handParentTransform.position;
        palm_rotation = hand_model.GetPalmRotation().eulerAngles - handParentTransform.eulerAngles;

        for (int i = 0; i < 5; i++)
        {
            finger_positions[i] = leap_hand.Fingers[i].TipPosition;
        }

        guiTxt.text = "palm position : (" +
            palm_position.x + ", " +
            palm_position.y + ", " +
            palm_position.z +
            ")\n palm rotation : (" +
            palm_rotation.x + ", " +
            palm_rotation.y + ", " +
            palm_rotation.z + ")";

        for (int i = 0; i < 5; i++)
        {
            guiTxt.text += "\n finger " + i + " : (" +
                finger_positions[i].x + ", " +
                finger_positions[i].y + ", " +
                finger_positions[i].z + ")";
        }
    }
}
