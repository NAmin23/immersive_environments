using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MagicEffect
{
    public float scale = 2.0f;
    public override void EndEffectForTarget(MagicAffected target)
    {
        target.transform.localScale /= scale;
    }

    public override float GetDuration()
    {
        return 3.0f;
    }

    public override void StartEffectForTarget(MagicAffected target)
    {
        target.transform.localScale *= scale;
    }

    public override void TickEffectForTarget(MagicAffected target)
    {
    }

    public override bool AffectOrigin()
    {
        return true;
    }
}
