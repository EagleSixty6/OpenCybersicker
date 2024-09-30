using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SickerControlDemo : SickerControl
{
    public float speedPercentage = 0.0f;
    private bool studyRuns = false;

    public InputActionAsset inputActions;
    private InputAction FasterAction;
    private InputAction EmergencyAction;

    void Start()
    {
        // Reference to the action map
        var touchControllerMap = inputActions.FindActionMap("TouchController");

        // Get the actions for Button A and B
        FasterAction = touchControllerMap.FindAction("Faster");
        EmergencyAction = touchControllerMap.FindAction("EmergencyStop");

        // Enable actions
        FasterAction.Enable();
        EmergencyAction.Enable();
    }

    void OnDisable()
    {
        // Disable actions when not needed
        FasterAction.Disable();
        EmergencyAction.Disable();
    }

    protected virtual void Update()
    {
        if (EmergencyAction.WasPressedThisFrame())
        {
            speedPercentage += 0.0f;
            firstLevelSpeed = 0f;
            secondLevelSpeed = 0f;
            thirdLevelSpeed = 0f;
            bobSpeed = 0f;
            studyRuns = false;
        }

        if (studyRuns && FasterAction.WasPressedThisFrame())
        {
            speedPercentage += 0.04f;
            firstLevelSpeed = 200f * speedPercentage;
            secondLevelSpeed = 100f * speedPercentage;
            thirdLevelSpeed = 50f * speedPercentage;
            bobSpeed = 5f * speedPercentage;
        }


        if (!studyRuns && FasterAction.WasPressedThisFrame())
        {
            studyRuns = true;
            speedPercentage += 0.04f;
            firstLevelSpeed = 200f * speedPercentage;
            secondLevelSpeed = 100f * speedPercentage;
            thirdLevelSpeed = 50f * speedPercentage;
            bobSpeed = 5f * speedPercentage;
            FindAnyObjectByType<AudioSource>().Play();
        }
    }
}
