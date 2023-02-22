using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardNav : MonoBehaviour
{

    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var walk = Input.GetAxis("Vertical");
        var strafe = Input.GetAxis("Horizontal");


        var forward = Vector3.ProjectOnPlane(camera.transform.forward, this.transform.up).normalized;
        var right = Vector3.ProjectOnPlane(camera.transform.right, this.transform.up).normalized;

        this.transform.position += walk * forward * 0.05f;
        this.transform.position += strafe * right * 0.05f;
    }
}
