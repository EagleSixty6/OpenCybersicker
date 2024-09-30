using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelRotate : Rotate
{
    protected override float GetRotationSpeed()
    {
        return this.transform.parent.transform.parent.transform.parent.GetComponent<SickerControl>().secondLevelSpeed;
    }
}
