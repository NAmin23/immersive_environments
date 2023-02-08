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
        mr.material.SetColor("_Emission", new Color(Random.value, Random.value, Random.value));
        mr.material.SetColor("_Emission_2", new Color(Random.value, Random.value, Random.value));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
