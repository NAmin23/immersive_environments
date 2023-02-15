using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicEffect : MonoBehaviour
{
    public Vector3 initialTargetLocation;
    public Vector3 initialCastLocation;

    public MagicAffected mainTarget;
    private HashSet<MagicAffected> targets;

    public float timeRemaining = 3.0f;

    public bool destroyObjOnFinish = true;

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

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            foreach (var target in targets)
            {
                EndEffectForTarget(target);
            }

            if (destroyObjOnFinish)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        foreach (var target in targets)
        {
            TickEffectForTarget(target);
        }
    }

    public abstract void StartEffectForTarget(MagicAffected target);
    public abstract void TickEffectForTarget(MagicAffected target);
    public abstract void EndEffectForTarget(MagicAffected target);
}
