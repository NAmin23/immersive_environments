using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject pancake;
    public Transform pancakeTransform;

    public void spawnPancake()
    {
        GameObject newPancake;
        newPancake = Instantiate(pancake, pancakeTransform);
        newPancake.SetActive(true);
        Debug.Log("pancake spawned");
    }
}
