using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    private static Narrator ms_Instance;
    public static Narrator Instance
    {
        get { return ms_Instance; }
    }

    private AudioSource m_AudioSource;
    private Queue<NarrationLine> m_QueuedLines = new Queue<NarrationLine>();
    private NarrationLine m_CurrentLine;

    public NarrationLine CurrentLine
    {
        get { return m_CurrentLine; }
    }

    void Awake()
    {
        ms_Instance = this;
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!m_AudioSource.isPlaying)
        {
            m_CurrentLine = null;
            if (m_QueuedLines.Count > 0)
            {
                m_CurrentLine = m_QueuedLines.Dequeue();
                m_AudioSource.PlayOneShot(m_CurrentLine.Clip);
            }
        }
    }

    public void ScheduleClips(NarrationLine[] lines)
    {
        ResetNarration();
        foreach (NarrationLine line in lines)
            m_QueuedLines.Enqueue(line);
    }

    public void ResetNarration()
    {
        m_AudioSource.Stop();
        m_CurrentLine = null;
        m_QueuedLines.Clear();
    }
}
