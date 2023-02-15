using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Smash : MonoBehaviour
{

    [System.Serializable]
    public class CollisionEvent : UnityEvent<Collision>
    {

    }


    public float impulseThreshold = 5.0f;
    public CollisionEvent callback;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude >= impulseThreshold)
        {
            callback.Invoke(collision);
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
