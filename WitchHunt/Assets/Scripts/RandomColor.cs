using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mr = this.GetComponent<MeshRenderer>();

        mr.material.SetColor("_Base_Color", new Color(Random.value, Random.value, Random.value));
        mr.material.SetColor("_Base_Color_2", new Color(Random.value, Random.value, Random.value));
        mr.material.SetColor("_Emission", Color.HSVToRGB(Random.value, 1.0f, 1.0f) * Random.value * 10.0f);
        mr.material.SetColor("_Emission_2", Color.HSVToRGB(Random.value, 1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
