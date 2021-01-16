using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    private bool m_NeedRefresh = false;
    private Image m_Image = null;
    private Text[] m_Texts = null;


    private InventoryItem m_Item;
    public InventoryItem Item
    {
        get { return m_Item; }
        set
        {
            m_Item = value;
            m_NeedRefresh = true;
        }
    }

    void Awake()
    {
        m_Image = GetComponent<Image>();
        m_Texts = GetComponentsInChildren<Text>();
    }

    void Update()
    {
        if (m_NeedRefresh)
        {
            m_NeedRefresh = false;
            RefreshVisual();
        }
    }

    void RefreshVisual()
    {
        if (m_Item != null)
        {
            m_Image.enabled = true;
            m_Image.sprite = m_Item.Sprite;
            m_Image.color = m_Item.Color;

            foreach (Text text in m_Texts)
            {
                text.enabled = true;
                text.text = m_Item.Name;
            }
        }
        else
        {
            m_Image.enabled = false;

            foreach (Text text in m_Texts)
            {
                text.enabled = false;
            }
        }
    }
}
