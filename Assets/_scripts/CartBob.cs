using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartBob : Rotate
{
    private float time = 0.0f;

    protected virtual void Start()
    {
        currentAngularVelocity = GetRotationSpeed();
    }

    protected override void Update()
    {
       
        float targetAngularVelocity = GetRotationSpeed();
        currentAngularVelocity = Mathf.SmoothDamp(currentAngularVelocity, targetAngularVelocity, ref dampingVelo, FindObjectOfType<SickerControl>().dampingTime);
        time += Time.deltaTime * currentAngularVelocity;

        this.transform.localEulerAngles = new Vector3(Mathf.Sin(time) * 15.0f , this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
   
    }

    protected override float GetRotationSpeed()
    {
        return FindObjectOfType<SickerControl>().bobSpeed;
    }
}
