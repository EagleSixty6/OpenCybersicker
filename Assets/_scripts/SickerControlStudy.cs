using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickerControlStudy : SickerControl
{
    public float timeFrame;
    public float maxTotalTime;
    public float speedPercentage = 0.0f;
    private float time = 0.0f;
    private float totalTime = 0.0f;
    private bool studyRuns = false;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || totalTime > maxTotalTime)
        {
            speedPercentage += 0.0f;
            firstLevelSpeed = 0f;
            secondLevelSpeed = 0f;
            thirdLevelSpeed = 0f;
            bobSpeed = 0f;
            Debug.Log("Gesamtzeit: " + totalTime);
            totalTime = 0.0f;
            studyRuns = false;
        }

        if (studyRuns)
        {
            time += Time.deltaTime;
            totalTime += Time.deltaTime;
        }

        if (time >= timeFrame)
        {
            time = 0.0f;
            speedPercentage += 0.04f;
            firstLevelSpeed = 200f * speedPercentage;
            secondLevelSpeed = 100f * speedPercentage;
            thirdLevelSpeed = 50f * speedPercentage;
            bobSpeed = 5f * speedPercentage;

        }
        else if(time + 10.0f >= timeFrame)
        {
            Debug.Log("In 10s Erhöhung auf " + (speedPercentage + 0.04f));
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            studyRuns = true;
            time = Mathf.Infinity;
        }
    }
}
