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

    public List<GameObject> Lights;

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
        for (int i = 0; i < shrunkObjects.Count; i++)
        {
            shrunkObjects[i].transform.localScale *= UnityEngine.Random.Range(0.25f, 2.5f);
        }

        particleEffect.SetActive(false);
    }

    public void colorChange()
    {
        foreach(var light in Lights)
        {
            Light lt;
            lt = light.GetComponent<Light>();
            lt.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }
        particleEffect.SetActive(false);
    }
}
