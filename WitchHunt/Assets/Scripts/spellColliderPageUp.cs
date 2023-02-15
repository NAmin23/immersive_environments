using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spellColliderPageUp : MonoBehaviour
{
    public GameObject spellbook;
    public TMP_Text leftInputText;
    public Transform centralEyeAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL")
        {
            String temp = "PageUp";
            leftInputText.text = temp;

            //Page up function
            // Sound effect
        }
    }

    private void Update()
    {
        gameObject.transform.position = centralEyeAnchor.position + new Vector3(0.35f, -0.25f, 0.16f);
    }
}
