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

    private HashSet<Grabbable> grabCandidates = new HashSet<Grabbable>();
    private Grabbable bestGrabCandidate = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        this.deltaPosition = (this.transform.position - this.lastPosition) / Time.fixedDeltaTime;
        this.lastPosition = this.transform.position;
    }

    void Update()
    {
        var newBestGrabCandidate = getBestGrabCandidate();
        if (newBestGrabCandidate != null && newBestGrabCandidate != this.bestGrabCandidate)
        {
            if (this.bestGrabCandidate != null)
            {
                this.bestGrabCandidate.Unhighlight();
            }
            this.bestGrabCandidate = newBestGrabCandidate;
            this.bestGrabCandidate.Highlight();
        }
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Grabbable>(out var grabbable))
        {
            this.grabCandidates.Remove(grabbable);
            if (grabbable == bestGrabCandidate)
            {
                bestGrabCandidate = null;
                grabbable.Unhighlight();
            }
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
            this.grabbed.TryRelease();
            this.grabbed.rb.velocity = this.deltaPosition;
        }
        return false;
    }
}
