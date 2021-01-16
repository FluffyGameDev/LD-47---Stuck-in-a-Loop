using UnityEngine;

public class FlowStateChanger : MonoBehaviour
{
    [SerializeField]
    private EFlowState RequestedState;

    public void ApplyFlowState()
    {
        FlowStateMachine.Instance.FlowState = RequestedState;
    }
}
