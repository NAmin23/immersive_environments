using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject rightHandObject;
    public GameObject rightHandDisplay;
    public List<GameObject> disableOnPancake;

    public HandController handControls;

    private Vector2 handXYOffset;
    private float handDistance = 0.5f;

    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string yAxis = "Mouse Y";

    void Start()
    {

        if (!OVRManager.isHmdPresent)
        {
            foreach (var obj in disableOnPancake)
            {
                obj.SetActive(false);
            }

            rightHandDisplay.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.handControls.TryStartGrab();
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.handControls.TryEndGrab();
        }

        var xDelta = Input.GetAxis(xAxis) * sensitivity;
        var yDelta = Input.GetAxis(yAxis) * sensitivity;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Move hand on screen
            this.handXYOffset.x += xDelta * 0.01f;
            this.handXYOffset.y += yDelta * 0.01f;
        }
        else
        {
            // Rotate camera
            rotation.x += xDelta;
            rotation.y += yDelta;

            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

            cameraObject.transform.localRotation = xQuat * yQuat;
        }

        // Move hand.
        this.handDistance = Mathf.Clamp(this.handDistance + Input.mouseScrollDelta.y * 0.1f, 0.3f, 3.0f);

        rightHandObject.transform.SetPositionAndRotation(
            cameraObject.transform.localToWorldMatrix * new Vector4(
                this.handXYOffset.x,
                this.handXYOffset.y,
                this.handDistance,
                1.0f
            ),
            cameraObject.transform.rotation
        );
    }
}
