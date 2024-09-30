using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelRotate : Rotate
{
    private int direction = 1;
    private float saturationTimer;
  
    protected override void Start()
    {
        saturationTimer = FindObjectOfType<SickerControl>().saturationTime;
        base.Start();
        
    }

    protected override void Update()
    {
        if (FindObjectOfType<SickerControl>().alterFirstLevelDirection)
        {
            if (saturationTimer < 0)
            {
                // TODO!! adapt to level 2, anti direction has to be adapted to be perceived the same, has it?
                if (direction == -1)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }

                saturationTimer = FindObjectOfType<SickerControl>().saturationTime;
            }
            else
            {
                saturationTimer -= Time.deltaTime;
            }
        }
        else
        {
            direction = 1;
        }

        base.Update();
    }

    protected override float GetRotationSpeed()
    {
        return FindObjectOfType<SickerControl>().firstLevelSpeed * direction;
    }
}
