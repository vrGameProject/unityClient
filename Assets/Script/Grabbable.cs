﻿using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour
{
    public Rigidbody rbody_;

    public bool useAxisAlignment = false;
    public Vector3 rightHandAxis;
    public Vector3 objectAxis;

    public bool rotateQuickly = true;
    public bool centerGrabbedObject = false;

    public Rigidbody breakableJoint;
    public float breakForce;
    public float breakTorque;

    protected bool grabbed_ = false;
    protected bool hovered_ = false;

    void Start()
    {
        rbody_ = GetComponent<Rigidbody>();
    }

    public bool IsHovered()
    {
        return hovered_;
    }

    public bool IsGrabbed()
    {
        return grabbed_;
    }

    public virtual void OnStartHover()
    {
        hovered_ = true;
    }

    public virtual void OnStopHover()
    {
        hovered_ = false;
    }

    public virtual void OnGrab()
    {
        grabbed_ = true;
        hovered_ = false;

        if (breakableJoint != null)
        {
            Joint breakJoint = breakableJoint.GetComponent<Joint>();
            if (breakJoint != null)
            {
                breakJoint.breakForce = breakForce;
                breakJoint.breakTorque = breakTorque;
            }
        }
    }

    public virtual void OnRelease()
    {
        grabbed_ = false;

        if (breakableJoint != null)
        {
            Joint breakJoint = breakableJoint.GetComponent<Joint>();
            if (breakJoint != null)
            {
                breakJoint.breakForce = Mathf.Infinity;
                breakJoint.breakTorque = Mathf.Infinity;
            }
        }
        rbody_.velocity = Vector3.zero;
    }
}
