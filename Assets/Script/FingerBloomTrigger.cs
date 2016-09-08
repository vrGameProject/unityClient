using UnityEngine;
using System.Collections;
using Leap;

public class FingerBloomTrigger : MonoBehaviour {


    // Ratio of the length of the proximal bone of the thumb that will trigger a pinch.
    public float grabTriggerDistance = 0.7f;

    // Ratio of the length of the proximal bone of the thumb that will trigger a release.
    public float releaseTriggerDistance = 1.2f;

    public GUIText guiTxt;

    public enum BloomState
    {
        Pinched,
        Released
    }

    protected BloomState bloom_state_;

    // Use this for initialization
    void Start () {
        bloom_state_ = BloomState.Released;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void StartPinch()
    {
        guiTxt.text = "Pinced";
    }

    private void OnRelease()
    {
        guiTxt.text = "Released";

    }

    private BloomState GetNewBloomState(HandModel hand_model, Hand leap_hand)
    {
        Vector leap_thumb_tip = leap_hand.Fingers[0].TipPosition;
        float closest_distance = Mathf.Infinity;
        float average_distance = 0.0f;

        // Check thumb tip distance to joints on all other fingers.
        // If it's close enough, you're pinching.
        for (int i = 1; i < HandModel.NUM_FINGERS; ++i)
        {
            Finger finger = leap_hand.Fingers[i];

            for (int j = 0; j < FingerModel.NUM_BONES; ++j)
            {
                Vector leap_joint_position = finger.Bone((Bone.BoneType)j).NextJoint;

                float thumb_tip_distance = leap_joint_position.DistanceTo(leap_thumb_tip);
                closest_distance = Mathf.Min(closest_distance, thumb_tip_distance);
            }

            average_distance += closest_distance;
            closest_distance = Mathf.Infinity;
        }

        average_distance /= 4;

        // Scale trigger distance by thumb proximal bone length.
        float proximal_length = leap_hand.Fingers[0].Bone(Bone.BoneType.TYPE_PROXIMAL).Length;
        float trigger_distance = proximal_length * grabTriggerDistance;
        float release_distance = proximal_length * releaseTriggerDistance;

        if (average_distance <= trigger_distance)
            return BloomState.Pinched;
        if (average_distance <= release_distance && bloom_state_ != BloomState.Released)
            return BloomState.Pinched;
        else
            return BloomState.Released;
    }

    void FixedUpdate()
    {
        HandModel hand_model = GetComponent<HandModel>();
        Hand leap_hand = hand_model.GetLeapHand();

        if (leap_hand == null)
            return;

        BloomState new_bloom_state = GetNewBloomState(hand_model, leap_hand);
        if (bloom_state_ == BloomState.Pinched)
        {
            if (new_bloom_state == BloomState.Released)
                OnRelease();
        }
        else
        {
            if (new_bloom_state == BloomState.Pinched)
                StartPinch();
        }
        bloom_state_ = new_bloom_state;
    }
}
