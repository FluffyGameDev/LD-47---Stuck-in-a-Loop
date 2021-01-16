using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField]
    private string DisplayedPrefix;

    [SerializeField]
    private string ExpectedPassword;

    [SerializeField]
    private Text TextField;

    [SerializeField]
    private Color IdleColor;

    [SerializeField]
    private Color SuccessColor;

    [SerializeField]
    private Color FailColor;

    [SerializeField]
    private float FreezeDuration;

    [SerializeField]
    private UnityEvent OnPasswordCorrect;


    private Interactable[] m_Interactables;
    private string m_CurrentPassword;
    private float m_UnfreezeTime = 1.0f;
    private bool m_IsKeyboardFrozen = false;
    private bool m_IsLocked = false;

    void Start()
    {
        m_Interactables = GetComponentsInChildren<Interactable>();
    }

    void Update()
    {
        if (m_IsKeyboardFrozen && Time.time > m_UnfreezeTime)
        {
            m_CurrentPassword = "";
            TextField.color = IdleColor;

            if (!m_IsLocked)
            {
                SetKeyboardFrozen(false);
                Updatetext();
            }
            else
            {
                TextField.text = "";
                SetKeyboardFrozen(true);
            }
        }
    }

    public void LockKeypad()
    {
        if (!m_IsKeyboardFrozen)
        {
            TextField.text = "";
            SetKeyboardFrozen(true);
        }
        m_IsLocked = true;
    }

    public void UnlockKeypad()
    {
        m_CurrentPassword = "";
        Updatetext();
        SetKeyboardFrozen(false);
        m_IsLocked = false;
    }

    public void InputCharacter(string c)
    {
        m_CurrentPassword += c;
        Updatetext();
        CheckPassword();
    }

    void Updatetext()
    {
        TextField.text = DisplayedPrefix + m_CurrentPassword;
    }

    private void CheckPassword()
    {
        if (m_CurrentPassword.Length == ExpectedPassword.Length)
        {
            SetKeyboardFrozen(true);
            m_UnfreezeTime = Time.time + FreezeDuration;

            if (m_CurrentPassword == ExpectedPassword)
            {
                TextField.color = SuccessColor;
                OnPasswordCorrect?.Invoke();
            }
            else
            {
                TextField.color = FailColor;
            }
        }
    }

    private void SetKeyboardFrozen(bool frozen)
    {
        foreach (Interactable interactable in m_Interactables)
            interactable.enabled = !frozen;
        m_IsKeyboardFrozen = frozen;
    }
}
