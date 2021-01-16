using System;
using UnityEngine;
using UnityEngine.UI;

public class UICountdown : MonoBehaviour
{
    [SerializeField]
    private Countdown DisplayedCountdown;
    [SerializeField]
    private int WarningTimeLeft = 0;
    [SerializeField]
    private Color IdleColor;
    [SerializeField]
    private Color WarningColor;

    private Text m_Text;
    private AudioSource m_AudioSource;
    private int m_PreviousDisplayedTime = 0;

    void Start()
    {
        m_Text = GetComponent<Text>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Color displayedColor = IdleColor;
        string displayedText = "";
        if (DisplayedCountdown.IsStarted)
        {
            int displayedTime = Math.Max((int)(DisplayedCountdown.CountdownEndTime - Time.time) + 1, 0);
            displayedText = string.Format("00:{0:00}", displayedTime);
            
            if (displayedTime <= WarningTimeLeft)
            {
                displayedColor = WarningColor;
            }

            if (displayedTime != m_PreviousDisplayedTime)
            {
                if (displayedTime <= WarningTimeLeft)
                {
                    m_AudioSource.Play();
                }
                m_PreviousDisplayedTime = displayedTime;
            }
        }
        m_Text.text = displayedText;
        m_Text.color = displayedColor;
    }
}
