using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class HandController : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 deltaPosition;

    private Grabbable grabbed;
    public Rigidbody rb;

    HashSet<Grabbable> grabCandidates = new HashSet<Grabbable>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.deltaPosition = (this.transform.position - this.lastPosition) / Time.fixedDeltaTime;
        Debug.Log(this.deltaPosition);
        this.lastPosition = this.transform.position;
    }

    private Grabbable getBestGrabCandidate()
    {
        Grabbable bestCandidate = null;
        float bestDistanceSqr = float.PositiveInfinity;
        foreach (var candidate in this.grabCandidates)
        {
            float distanceSqr = (candidate.gameObject.transform.position - this.transform.position).sqrMagnitude;
            if (distanceSqr < bestDistanceSqr)
            {
                bestDistanceSqr = distanceSqr;
                bestCandidate = candidate;
            }
        }
        return bestCandidate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Grabbable>(out var grabbable))
        {
            this.grabCandidates.Add(grabbable);
            Debug.Log(this.grabCandidates.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Grabbable>(out var grabbable))
        {
            this.grabCandidates.Remove(grabbable);
            Debug.Log(this.grabCandidates.Count);
        }
    }

    public bool TryStartGrab()
    {
        Grabbable grabTarget = this.getBestGrabCandidate();
        if (grabTarget != null)
        {
            if (grabTarget.TryGrab(this))
            {
                this.grabbed = grabTarget;
            }
        }
        return false;
    }

    public bool TryEndGrab()
    {
        if (this.grabbed)
        {
            Debug.Log(this.deltaPosition);
            this.grabbed.TryRelease();
            this.grabbed.rb.velocity = this.deltaPosition;
        }
        return false;
    }
}
