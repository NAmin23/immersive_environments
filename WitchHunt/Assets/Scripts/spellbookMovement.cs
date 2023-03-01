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
    private int pageNum = 0;

    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
        if(movingUp)
        {
            if(i < 1)
            {
                gameObject.transform.position = Vector3.Lerp(currPos.position, spellbookDest.position, i);
                i = i + 0.01f;
            }
        }
        else
        {
            if(i < 1)
            {
                gameObject.transform.position = Vector3.Lerp(currPos.position, spellbookOrigin.position, i);
                i = i + 0.01f;
            }
            if (i >= 1)
            {
                gameObject.SetActive(false);
            }
        }
        
        PlayAnim();

    }

    public void PlayAnim()
    {
        //Keyboard controls
        if (anim != null)
        {
            if(Input.GetKeyDown("space"))
            {
                PlayOpenAnim();
            }

            if(Input.GetKeyUp("space"))
            {
                PlayCloseAnim();
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                PageTurnForward();
            }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                PageTurnBackward();
            }
        }
 
    }

    public void PlayOpenAnim()
    {
        if (anim != null)
        {
             anim.SetTrigger("TrOpen");
        }
    }

    public void PlayCloseAnim()
    {
        if (anim != null)
        {
            anim.SetTrigger("TrClose");
        }
    }

    public void PageTurnForward()
    {
        if (anim != null)
        {
            switch (pageNum)
            {
                case 0:
                    anim.SetTrigger("TrPageZero->One");
                    pageNum++;
                    break;

                case 1:
                    anim.SetTrigger("TrPageOne->Two");
                    pageNum++;
                    break;

                case 2:
                    anim.SetTrigger("TrPageTwo->Three");
                    pageNum++;
                    break;

            }
        }
    }

    public void PageTurnBackward()
    {
        if (anim != null)
        {
            switch (pageNum)
            {
                case 1:
                    anim.SetTrigger("TrPageOne->Zero");
                    pageNum--;
                    break;

                case 2:
                    anim.SetTrigger("TrPageTwo->One");
                    pageNum--;
                    break;

                case 3:
                    anim.SetTrigger("TrPageThree->Two");
                    pageNum--;
                    break;

            }
        }
    }
}
