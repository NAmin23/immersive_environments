using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMeshes : MonoBehaviour
{
    [System.Serializable]
    public class MeshList
    {
        public MeshFilter meshFilter;
        public List<Mesh> meshes;
    }

    public List<MeshList> meshLists;
    public bool independent = true;
    // Start is called before the first frame update
    void Start()
    {
        if (independent)
        {
            foreach (var meshList in meshLists)
            {
                meshList.meshFilter.mesh = meshList.meshes[Random.Range(0, meshList.meshes.Count)];
            }
        }
        else
        {
            int index = Random.Range(0, meshLists[0].meshes.Count);
            foreach (var meshList in meshLists)
            {
                meshList.meshFilter.mesh = meshList.meshes[index];
            }
        }
    }
}
