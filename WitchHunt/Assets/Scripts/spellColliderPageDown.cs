using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spellColliderPageDown : MonoBehaviour
{
    public GameObject spellbook;
    public TMP_Text leftInputText;
    public Transform centralEyeAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL" && spellbook.activeSelf)
        {
            String temp = "DownUp";
            leftInputText.text = temp;
            spellbook.GetComponent<spellbookMovement>().PageTurnBackward();
        }
    }

    private void Update()
    {
        gameObject.transform.position = centralEyeAnchor.position + new Vector3(-1.0f, -0.25f, 0.35f);
    }
}
