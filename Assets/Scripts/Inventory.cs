using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItem
{
    public InventoryItem(string name, string keyID, Color color, Sprite sprite)
    {
        Name = name;
        KeyID = keyID;
        Color = color;
        Sprite = sprite;
    }

    public string Name;
    public string KeyID;
    public Color Color;
    public Sprite Sprite;
}

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnInventoryChanged;

    private List<InventoryItem> m_Items = new List<InventoryItem>();
    public List<InventoryItem> Items
    {
        get { return m_Items; }
    }

    private static Inventory ms_Instance;
    public static Inventory Instance
    {
        get { return ms_Instance; }
    }

    void Awake()
    {
        ms_Instance = this;
    }

    public void ClearInventory()
    {
        m_Items.Clear();
        if (OnInventoryChanged != null)
        {
            OnInventoryChanged.Invoke();
        }
    }

    public void AddItem(InventoryItem item)
    {
        m_Items.Add(item);
        if (OnInventoryChanged != null)
        {
            OnInventoryChanged.Invoke();
        }
    }

    public bool HasKey(string keyID)
    {
        return m_Items.Any(x => x.KeyID == keyID);
    }

    public void UseKey(string keyID)
    {
        if (m_Items.RemoveAll(x => x.KeyID == keyID) > 0)
        {
            if (OnInventoryChanged != null)
            {
                OnInventoryChanged.Invoke();
            }
        }
    }
}
