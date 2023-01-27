using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "OVRHandPrefabL")
        {
            Debug.Log("hello");
        }
    }
}
