using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotate : MonoBehaviour
{
    protected float currentAngularVelocity;
    protected float dampingVelo = 0;

    protected virtual void Start()
    {
        currentAngularVelocity = GetRotationSpeed();
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        float targetAngularVelocity = GetRotationSpeed();
        currentAngularVelocity = Mathf.SmoothDamp(currentAngularVelocity, targetAngularVelocity, ref dampingVelo, FindObjectOfType<SickerControl>().dampingTime);
        this.transform.Rotate(Vector3.up, currentAngularVelocity * Time.deltaTime);
    }

    protected abstract float GetRotationSpeed();
}