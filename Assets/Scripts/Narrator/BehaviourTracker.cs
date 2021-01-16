using System;
using System.Linq;
using UnityEngine;

[Serializable]
class BehaviourComment
{
    public int RequiredTimerResets = 0;
    public NarrationLine[] Lines;
}

public class BehaviourTracker : MonoBehaviour
{
    [SerializeField]
    private BehaviourComment[] Comments;

    private int m_TimerResetCount = 0;
    private bool m_EscapeAttempt = false;

    public void NotifyEscapeAttempt()
    {
        m_EscapeAttempt = true;
    }
    public void NotifyTimerReset()
    {
        ++m_TimerResetCount;

        if (!m_EscapeAttempt)
        {
            foreach (BehaviourComment currentComment in Comments)
            {
                if (currentComment.RequiredTimerResets == m_TimerResetCount)
                {
                    Narrator.Instance.ScheduleClips(currentComment.Lines);
                    break;
                }
            }
        }
    }

    public void ResetTracker()
    {
        m_TimerResetCount = 0;
        m_EscapeAttempt = false;
    }   
}
