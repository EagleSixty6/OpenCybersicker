using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public float rotationSpeed;
    public float orientationMaxX;
    public float orientationMinX;
    public float localModificator;
    public float globalModificator;

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = Quaternion.Euler(  
            ((Mathf.Sin(Time.frameCount * 0.01f) + 1.0f) / 2.0f * (orientationMaxX - orientationMinX)) + orientationMinX, 
            ((Mathf.Sin(Time.frameCount * 0.01f) + 1.0f) / 2.0f * (orientationMaxX - orientationMinX)) + orientationMinX, 
            0
        );
        this.transform.rotation = rot;
        this.transform.Rotate(Vector3.up, Time.frameCount + localModificator);
        this.transform.Rotate(transform.parent.transform.right, globalModificator);
    }
}
