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
        if (Input.GetKeyDown(KeyCode.C))
        {
            //potions = GameObject.FindGameObjectsWithTag("Potion");
            potions = GameObject.Find("Potion");

            if (potions != null)
            {
                Debug.Log("ITS NULL");
            }

            for (i = 0; i < potions.Length; i++)
            {
                potion = potions[i];
                potion.transform.position = potion.transform.position + new Vector3(0.0f, 10.0f, 0.0f);

            }
        }
        
    }
}
