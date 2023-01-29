using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpellbookDown : MonoBehaviour
{
    public TMP_Text leftInputText;
    public GameObject spellbook;
    public Transform spellbookOrigin;
    public Transform spellbookDest;
    private float j = 0; // iterator for linear interpolation
    public GameObject spellbookUp;
    private bool lowering = false;
    public Transform centralEyeAnchor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRHandPrefabL" && gameObject.name == "SpellbookDown")
        {
            String temp = "Down";
            leftInputText.text = temp;

            j = 0;
            lowering = true;
            spellbook.transform.position = spellbookDest.position;
        }
    }

    void Update()
    {
        gameObject.transform.position = centralEyeAnchor.position + new Vector3(0.0f, -0.25f, 0.16f);

        if ((spellbook.activeSelf == true) && j < 1 && (spellbookUp.GetComponent<SpellbookUp>().raising == false) && (lowering == true))
        {
            spellbook.transform.position = Vector3.Lerp(spellbookDest.position, spellbookOrigin.position, j);
            j = j + 0.02f;
            //leftInputText.text = j.ToString();
        }

        if (j >= 1 && (Vector3.Distance(spellbook.transform.position, spellbookOrigin.position) < .02f))
        {
            spellbook.SetActive(false);
            lowering = false;
        }
    }
}
