using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class FlowStateWatcher : MonoBehaviour
{
    [SerializeField]
    EFlowState[] WatchedStates;
    [SerializeField]
    UnityEvent OnFlowChanged;

    void Start()
    {
        FlowStateMachine.Instance.FlowStateChangedEvent += FlowChangedCallback;
    }

    void FlowChangedCallback(EFlowState state)
    {
        if (WatchedStates.Contains(state))
        {
            OnFlowChanged?.Invoke();
        }
    }
}
