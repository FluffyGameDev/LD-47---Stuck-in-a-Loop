using System.Linq;
using UnityEngine;

public class FlowStateFilter : MonoBehaviour
{
    [SerializeField]
    EFlowState[] AllowedStates;

    void Start()
    {
        FlowStateMachine.Instance.FlowStateChangedEvent += ApplyFlowState;
        ApplyFlowState(FlowStateMachine.Instance.FlowState);
    }

    void ApplyFlowState(EFlowState state)
    {
        gameObject.SetActive(AllowedStates.Contains(state));
    }
}
