using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    FixedJoint joint;

    HandController grabbingHand;

    int highlighters = 0;

    GameObject outlineObj;

    public Material outlineMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        this.outlineObj = new GameObject("outline");
        this.outlineObj.transform.SetParent(this.transform);
        this.outlineObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        this.outlineObj.transform.localScale = Vector3.one;
        this.outlineObj.AddComponent<MeshFilter>().mesh = this.GetComponent<MeshFilter>().mesh;
        this.outlineObj.AddComponent<MeshRenderer>().material = outlineMaterial;
        this.outlineObj.SetActive(false);
    }

    public bool TryGrab(HandController hand)
    {
        grabbingHand = hand;
        joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = hand.rb;
        return true;
    }

    public bool TryRelease()
    {
        grabbingHand = null;
        Destroy(joint);
        return true;
    }

    public void Highlight()
    {
        highlighters += 1;
        if (highlighters == 1)
        {
            this.outlineObj.SetActive(true);
        }
    }

    public void Unhighlight()
    {
        highlighters -= 1;
        if (highlighters == 0)
        {
            this.outlineObj.SetActive(false);
        }
    }
}
