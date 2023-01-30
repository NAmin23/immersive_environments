using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellbookMovement : MonoBehaviour
{
    public Transform spellbookOrigin;
    public Transform spellbookDest;
    public float i; //iterator
    public Boolean movingUp;
    public Transform currPos;

    // Update is called once per frame
    void Update()
    {
        if(movingUp)
        {
            if(i < 1)
            {
                gameObject.transform.position = Vector3.Lerp(currPos.position, spellbookDest.position, i);
                i = i + 0.02f;
            }
        }
        else
        {
            if(i < 1)
            {
                gameObject.transform.position = Vector3.Lerp(currPos.position, spellbookOrigin.position, i);
                i = i + 0.02f;
            }
            if (i >= 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
