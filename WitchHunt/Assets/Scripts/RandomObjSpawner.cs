using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjSpawner : MonoBehaviour
{
    public List<GameObject> objs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objs[Random.Range(0, objs.Count)], this.transform, false).transform.SetParent(null);
        Destroy(this.gameObject);
    }
}
