using System;
using UnityEngine;

[Serializable]
public class NarrationLine
{
    public AudioClip Clip;
    public string ClipText;
}

public class NarratorClip : MonoBehaviour
{
    public NarrationLine[] Lines;

    public void ScheduleClip()
    {
        Narrator.Instance.ScheduleClips(Lines);
    }
}
