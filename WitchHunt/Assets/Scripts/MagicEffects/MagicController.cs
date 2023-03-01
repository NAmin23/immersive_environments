using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject pancake;
    public Transform pancakeTransform;

    public GameObject particleEffect;

    public List<GameObject> shrunkObjects;

    public void spawnPancake()
    {
        GameObject newPancake;
        newPancake = Instantiate(pancake, pancakeTransform);
        newPancake.SetActive(true);

        particleEffect.SetActive(false);
    }

    public void spawnBubbles()
    {
        particleEffect.SetActive(true);
    }

    public void shrinkObjects()
    {
        foreach (var shrinkObject in shrunkObjects)
        {
            shrinkObject.transform.localScale *= UnityEngine.Random.Range(0.1f, 3.0f);
        }

        particleEffect.SetActive(false);
    }
}
