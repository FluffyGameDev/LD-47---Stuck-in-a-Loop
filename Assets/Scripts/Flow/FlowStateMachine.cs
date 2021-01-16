using UnityEngine;

public enum EFlowState
{
    MainMenu,
    InGame,
    ResetWorld,
    GameEndSuccess,
    ExitGame,

    Invalid
}

public class FlowStateMachine : MonoBehaviour
{
    private static FlowStateMachine ms_Instance;
    public static FlowStateMachine Instance
    {
        get { return ms_Instance; }
    }

    public delegate void OnFlowStateChanged(EFlowState state);

    private EFlowState m_FlowState = EFlowState.Invalid;
    public EFlowState FlowState
    {
        get { return m_FlowState; }
        set
        {
            if (m_FlowState != value)
            {
                m_FlowState = value;
                FlowStateChangedEvent?.Invoke(m_FlowState);
            }
        }
    }

    public OnFlowStateChanged FlowStateChangedEvent;

    void Awake()
    {
        ms_Instance = this;

        FlowStateChangedEvent += OnFlowChanged;
        FlowState = EFlowState.MainMenu;
    }

    void Update()
    {
        if (m_FlowState == EFlowState.InGame && Input.GetButtonDown("Exit"))
        {
            FlowState = EFlowState.MainMenu;
        }
    }

    void OnFlowChanged(EFlowState state)
    {
        Cursor.lockState = (state == EFlowState.InGame ? CursorLockMode.Locked : CursorLockMode.None);

        if (state == EFlowState.ExitGame)
        {
            Application.Quit();
        }
    }
}
