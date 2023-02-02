using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    FixedJoint joint;

    HandController grabbingHand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool TryGrab(HandController hand)
    {
        grabbingHand = hand;
        joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = hand.rb;
        return true;
    }

    public bool TryRelease()
    {
        grabbingHand = null;
        Destroy(joint);
        return true;
    }
}
