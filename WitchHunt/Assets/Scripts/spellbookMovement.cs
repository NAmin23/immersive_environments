using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellbookMovement : MonoBehaviour
{
    public Transform spellbookOrigin;
    public Transform spellbookDest;
    private float i; //iterator
    public Boolean movingUp;
    public Boolean movingDown;
    public Transform currPos;

    // Update is called once per frame
    void Update()
    {
        if(movingUp)
        {
            spellbook.transform.position = Vector3.Lerp(currPos.position, spellbookDest.position, i);
            i = i + 0.02f
        }
        else if (movingDown)
        {
            spellbook.transform.position = Vector3.Lerp(currPos.position, spellbookOrigin.position, i);
            i = i + 0.02f
        }

    }
}
