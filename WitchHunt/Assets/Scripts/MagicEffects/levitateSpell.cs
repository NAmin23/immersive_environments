using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitateSpell : MonoBehaviour
{
    private int i = 0;
    private GameObject potion;
    private GameObject[] potions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            potions = GameObject.FindGameObjectsWithTag("Potion");
            //potions = GameObject.Find("Potion");

            if (potions != null)
            {
                Debug.Log("ITS NULL");
            }

            for (i = 0; i < 1; i++)
            {
                potion = GameObject.Find("Potion3(Clone)");
                potion.transform.position += new Vector3(0.0f, Random.Range(1.0f, 5.0f), 0.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Potion2(Clone)").transform.position += new Vector3(0.0f, Random.Range(1.0f, 5.0f), 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Find("Potion4(Clone)").transform.position += new Vector3(0.0f, Random.Range(1.0f, 5.0f), 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject.Find("Potion5(Clone)").transform.position += new Vector3(0.0f, Random.Range(1.0f, 5.0f), 0.0f);
        }

    }
}
