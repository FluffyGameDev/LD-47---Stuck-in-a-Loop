using UnityEngine;
using UnityEngine.UI;

public class UISubtitle : MonoBehaviour
{
    Image m_Image;
    Text m_TextField;

    void Awake()
    {
        m_Image = GetComponent<Image>();
        m_TextField = GetComponentInChildren<Text>();
    }

    void Update()
    {
        NarrationLine line = Narrator.Instance.CurrentLine;
        m_TextField.text = (line != null ? line.ClipText : "");
        m_Image.enabled = line != null;
    }
}
