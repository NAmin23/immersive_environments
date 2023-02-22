using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spellColliderUp : MonoBehaviour
{
    public GameObject spellbook;
    public TMP_Text leftInputText;
    public Transform centralEyeAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL")
        {
            String temp = "Up";
            leftInputText.text = temp;

            spellbook.SetActive(true);
            spellbook.GetComponent<spellbookMovement>().i = 0;
            spellbook.GetComponent<spellbookMovement>().movingUp = true;
            spellbook.GetComponent<spellbookMovement>().currPos = spellbook.gameObject.transform;
            spellbook.GetComponent<spellbookMovement>().PlayOpenAnim();
        }
    }

    private void Update()
    {
        gameObject.transform.position = centralEyeAnchor.position + new Vector3(0.0f, 0.09f, 0.16f);
    }
}
