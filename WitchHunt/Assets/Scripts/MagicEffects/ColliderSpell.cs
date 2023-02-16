using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MagicAffected))]
public class ColliderSpell : MonoBehaviour
{

    Dictionary<string, System.Type> effectTypes = new Dictionary<string, System.Type> { { "enlarge", typeof(Enlarge) } };
    public List<string> effectsToCreateOnSelf;
    public List<string> effectsToPutOnObjects;

    public HashSet<MagicEffect> selfEffects = new HashSet<MagicEffect>();

    void Start()
    {
        var ma = gameObject.GetComponent<MagicAffected>();
        foreach (var effectName in effectsToCreateOnSelf)
        {
            var effect = (MagicEffect)gameObject.AddComponent(effectTypes[effectName]);
            effect.SetOrigin(ma);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MagicAffected>(out var objMa))
        {
            foreach (var effectName in effectsToPutOnObjects)
            {
                var effect = (MagicEffect)other.gameObject.AddComponent(effectTypes[effectName]);
                effect.SetOrigin(objMa);
            }

            foreach (var effect in selfEffects)
            {
                effect.AddTarget(objMa);
            }
        }
    }

    private void OnTriggerLeave(Collider other)
    {
        if (other.gameObject.TryGetComponent<MagicAffected>(out var objMa))
        {
            foreach (var effect in selfEffects)
            {
                effect.RemoveTarget(objMa);
            }
        }
    }
}
