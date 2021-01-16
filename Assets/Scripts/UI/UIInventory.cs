using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    List<UIInventoryItem> m_Items;

    void Awake()
    {
        m_Items = GetComponentsInChildren<UIInventoryItem>().ToList();
    }

    public void RefreshItems()
    {
        List<InventoryItem> items = Inventory.Instance.Items;
        int maxIndex = Math.Min(items.Count, m_Items.Count);

        if (items.Count > m_Items.Count)
        {
            Debug.LogError("Inventory UI doesn't have enough slots.");
        }

        for (int i = 0; i < maxIndex; ++i)
        {
            m_Items[i].Item = items[i];
        }

        for (int i = maxIndex; i < m_Items.Count; ++i)
        {
            m_Items[i].Item = null;
        }
    }
}
