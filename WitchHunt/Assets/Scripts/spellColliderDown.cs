using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spellColliderDown : MonoBehaviour
{
    public GameObject spellbook;
    public TMP_Text leftInputText;
    public Transform centralEyeAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL")
        {
            String temp = "Down";
            leftInputText.text = temp;

            spellbook.GetComponent<spellbookMovement>().i = 0;
            spellbook.GetComponent<spellbookMovement>().movingUp = false;
            spellbook.GetComponent<spellbookMovement>().currPos = spellbook.gameObject.transform;
            spellbook.GetComponent<spellbookMovement>().PlayCloseAnim();
        }
    }

    private void Update()
    {
        gameObject.transform.position = centralEyeAnchor.position + new Vector3(0.0f, -1.5f, 0.16f);
    }
}
