using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(FixedJoint))]
public class Grabbable : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    FixedJoint joint;

    HandController grabbingHand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joint = GetComponent<FixedJoint>();
    }

    public bool TryGrab(HandController hand)
    {
        grabbingHand = hand;
        joint.connectedBody = hand.rb;
        return true;
    }

    public bool TryRelease()
    {
        grabbingHand = null;
        joint.connectedBody = null;
        return true;
    }
}
