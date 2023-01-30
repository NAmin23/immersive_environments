using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spellColliderUp : MonoBehaviour
{
    public GameObject spellbook;
    public TMP_Text leftInputText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL")
        {
            String temp = "Up";
            leftInputText.text = temp;

            spellbook.SetActive(true);
            spellbook.GetComponent<spellbookMovement>().i = 0;
            spellbook.GetComponent<spellbookMovement>().movingUp = true;
        }
    }
}
