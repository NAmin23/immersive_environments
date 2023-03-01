using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;
    public List<Gesture> gestures;
    private Gesture prevGesture;
    public float threshold = 0.1f; // Margin of error for gestures
    private int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        prevGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture()); // If current gesture hasn't been recognized already
        if(hasRecognized && !currentGesture.Equals(prevGesture))
        {
            Debug.Log("New gesture found:" + currentGesture.name);
            prevGesture = currentGesture;
            currentGesture.onRecognized.Invoke();
        }
    }

    void Save()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);

        Gesture g = new Gesture();
        g.name = "New Gesture" + i;
        i++;
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
            //finger position relative to root
        }
        g.fingerData = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currGesture = new Gesture();
        float currMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currData, gesture.fingerData[i]);

                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance; // If not discarded
            }

            if (!isDiscarded && sumDistance < currMin)
            {
                currMin = sumDistance;
                currGesture = gesture;
            }
        }

        return currGesture;
    }
}
