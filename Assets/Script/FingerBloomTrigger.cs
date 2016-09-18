using UnityEngine;
using System.Collections;
using Leap;

public class FingerBloomTrigger : MonoBehaviour {

    private MagicSpellControl magicSpellControl_;
    // Ratio of the length of the proximal bone of the thumb that will trigger a pinch.
    public float pinchTriggerDistance = 0.8f;

    // Ratio of the length of the proximal bone of the thumb that will trigger a release.
    public float releaseTriggerDistance = 1.2f;

    public enum BloomState
    {
        Pinched,
        Bloomed,
        Pointed,
        Middled
    }

    protected BloomState bloom_state_;

    // Use this for initialization
    void Start () {
        magicSpellControl_ = MagicSpellControl.singletonInstance;
        bloom_state_ = BloomState.Bloomed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerPinch()
    {
        magicSpellControl_.setMaigc(MagicSpellControl.MAGIC_FIREBALL);
    }

    private void OnTriggerPoint()
    {
        magicSpellControl_.setMaigc(MagicSpellControl.MAGIC_ICEBALL);
    }

    private void OnTriggerMiddle()
    {
    }

    private void OnTriggerBloom()
    {
        magicSpellControl_.setMaigc(MagicSpellControl.MAGIC_LIGHTBALL);
    }

    private void OnTriggerClap()
    {
        GameManager.singletonInstance.Restart();
    }

    private BloomState GetNewBloomState(HandModel hand_model, Hand leap_hand)
    {
        Vector leap_thumb_tip = leap_hand.Fingers[0].TipPosition;
        Vector leap_point_tip = leap_hand.Fingers[1].TipPosition;
        float closest_distance = Mathf.Infinity;
        float average_distance = 0.0f;
        float point_distance = 0.0f;
        float middle_distance = 0.0f;

        // Check thumb tip distance to joints on all other fingers.
        // If it's close enough, you're pinching.
        for (int i = 1; i < HandModel.NUM_FINGERS; ++i)
        {
            Finger finger = leap_hand.Fingers[i];

            float thumb_tip_distance = finger.TipPosition.DistanceTo(leap_thumb_tip);

            if (i ==1)
            {
                point_distance = thumb_tip_distance;
            } else if (i == 2)
            {
                middle_distance = thumb_tip_distance;
            }

            closest_distance = Mathf.Min(closest_distance, thumb_tip_distance);

            average_distance += closest_distance;
            closest_distance = Mathf.Infinity;
        }

        average_distance /= 4;

        // Scale trigger distance by thumb proximal bone length.
        float proximal_length = leap_hand.Fingers[0].Bone(Bone.BoneType.TYPE_PROXIMAL).Length;
        float pinch_trigger_distance = proximal_length * pinchTriggerDistance;
        float release_trigger_distance = proximal_length * releaseTriggerDistance;

        if (average_distance <= pinch_trigger_distance)
            return BloomState.Pinched;
        else if (average_distance <= release_trigger_distance && bloom_state_ == BloomState.Pinched)
            return BloomState.Pinched;
        else
        {
            BloomState result = BloomState.Pinched;
            if (point_distance > release_trigger_distance)
                result = BloomState.Pointed;
            if (middle_distance > release_trigger_distance)
                result = BloomState.Middled;
            if (point_distance > release_trigger_distance && middle_distance > release_trigger_distance)
                result = BloomState.Bloomed;
            return result;
        }
    }

    void FixedUpdate()
    {
        HandModel hand_model = GetComponent<HandModel>();
        Hand leap_hand = hand_model.GetLeapHand();

        if (leap_hand == null)
            return;

        BloomState new_bloom_state = GetNewBloomState(hand_model, leap_hand);

        switch (new_bloom_state)
        {
            case BloomState.Pinched:
                OnTriggerPinch();
                break;
            case BloomState.Pointed:
                OnTriggerPoint();
                break;
            case BloomState.Middled:
                OnTriggerMiddle();
                break;
            case BloomState.Bloomed:
                OnTriggerBloom();
                break;
            default:
                break;
        }
        bloom_state_ = new_bloom_state;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name.Equals("RigidHand"))
        {
            OnTriggerClap();
        }
    }
}
