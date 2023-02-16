using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicEffect : MonoBehaviour
{
    public Vector3 initialTargetLocation;
    public Vector3 initialCastLocation;

    private MagicAffected mainTarget;
    private HashSet<MagicAffected> targets;

    private float timeRemaining = 30.0f;

    // Return 0 to run once. 
    // Return negative to run forever.
    public abstract float GetDuration();

    public void SetMainTarget(MagicAffected target)
    {
        if (this.mainTarget != null)
        {
            this.RemoveTarget(this.mainTarget);
        }
        this.mainTarget = target;
        if (this.mainTarget != null && this.TreatMainTargetAsTarget())
        {
            this.AddTarget(this.mainTarget);
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

    public abstract bool TreatMainTargetAsTarget();

    void Start()
    {
        this.timeRemaining = GetDuration();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining >= 0 || this.GetDuration() < 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                foreach (var target in targets)
                {
                    EndEffectForTarget(target);
                }

                if (this.mainTarget != null)
                {
                    this.RemoveTarget(this.mainTarget);
                }
            }

            foreach (var target in targets)
            {
                TickEffectForTarget(target);
            }
        }
    }

    public abstract void StartEffectForTarget(MagicAffected target);
    public abstract void TickEffectForTarget(MagicAffected target);
    public abstract void EndEffectForTarget(MagicAffected target);
}
