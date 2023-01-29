using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpellbookUp : MonoBehaviour
{
    public TMP_Text leftInputText;
    public GameObject spellbook;
    public Transform spellbookOrigin;
    public Transform spellbookDest;
    private float i = 0; // iterator for linear interpolation
    public bool raising = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL")
        {
            String temp = "Raise";
            leftInputText.text = temp;

            spellbook.SetActive(true);
            spellbook.transform.position = spellbookOrigin.position;
            i = 0;
            raising = true;
        }
    }

    void Update()
    {
        if ((spellbook.activeSelf == true) && (raising == true)) ;
        {
            if (i < 1)
            {
                spellbook.transform.position = Vector3.Lerp(spellbookOrigin.position, spellbookDest.position, i);
                i = i + 0.02f;
            }
        }

        if(i >= 1)
        {
            raising = false;
        }
    }
}
