using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicEffect : MonoBehaviour
{
    public Vector3 initialTargetLocation;
    public Vector3 initialCastLocation;

    private MagicAffected origin;
    private HashSet<MagicAffected> targets = new HashSet<MagicAffected>();

    private bool finished = false;

    private float timeRemaining = 3.0f;

    // Return 0 to run once. 
    // Return negative to run forever.
    public abstract float GetDuration();

    public void SetOrigin(MagicAffected target)
    {
        if (target == this.origin)
        {
            return;
        }

        if (this.origin != null && this.AffectOrigin())
        {
            this.EndEffectForTarget(this.origin);
        }
        this.origin = target;
        if (this.origin != null && this.AffectOrigin())
        {
            this.StartEffectForTarget(this.origin);
        }
    }

    public void AddTarget(MagicAffected target)
    {
        StartEffectForTarget(target);
        targets.Add(target);
    }

    public void RemoveTarget(MagicAffected target)
    {
        EndEffectForTarget(target);
        targets.Remove(target);
    }

    public abstract bool AffectOrigin();

    void Start()
    {
        this.timeRemaining = GetDuration();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.finished)
        {
            return;
        }

        foreach (var target in targets)
        {
            TickEffectForTarget(target);
        }

        timeRemaining -= Time.deltaTime;

        if (this.GetDuration() == 0 || (this.GetDuration() > 0 && timeRemaining < 0))
        {
            this.finished = true;

            if (timeRemaining <= 0)
            {
                foreach (var target in targets)
                {
                    EndEffectForTarget(target);
                }

                if (this.origin != null && this.AffectOrigin())
                {
                    this.EndEffectForTarget(this.origin);
                }
            }
        }
    }

    public abstract void StartEffectForTarget(MagicAffected target);
    public abstract void TickEffectForTarget(MagicAffected target);
    public abstract void EndEffectForTarget(MagicAffected target);
}
