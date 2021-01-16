using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private float CountdownDuration = 30.0f;

    public bool IsStarted = false;
    public float CountdownEndTime;

    void Update()
    {
        if (IsStarted && Time.time > CountdownEndTime)
        {
            FlowStateMachine.Instance.FlowState = EFlowState.ResetWorld;
            FlowStateMachine.Instance.FlowState = EFlowState.InGame;
        }
    }

    public void ActivateCountdown()
    {
        IsStarted = true;
        ResetCountdown();
    }

    public void DeactivateCountdown()
    {
        IsStarted = false;
    }

    public void ResetCountdown()
    {
        CountdownEndTime = Time.time + CountdownDuration;
    }
}
