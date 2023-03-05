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

    public AudioSource pancakeAudio;
    public AudioSource shrinkAudio;
    public AudioSource lightingAudio;
    public AudioSource bubbleAudio;

    public void spawnPancake()
    {
        pancakeAudio.Play();
        GameObject newPancake;
        newPancake = Instantiate(pancake, pancakeTransform);
        newPancake.SetActive(true);

        particleEffect.SetActive(false);
    }

    public void spawnBubbles()
    {
        particleEffect.SetActive(true);
        bubbleAudio.Play();
    }

    public void shrinkObjects()
    {
        shrinkAudio.Play();
        for (int i = 0; i < shrunkObjects.Count; i++)
        {
            shrunkObjects[i].transform.localScale *= UnityEngine.Random.Range(0.25f, 2.0f);
        }

        particleEffect.SetActive(false);
    }

    public void colorChange()
    {
        lightingAudio.Play();
        foreach (var light in Lights)
        {
            Light lt;
            lt = light.GetComponent<Light>();
            lt.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }
        particleEffect.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnPancake();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spawnBubbles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shrinkObjects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            colorChange();
        }
    }
}
