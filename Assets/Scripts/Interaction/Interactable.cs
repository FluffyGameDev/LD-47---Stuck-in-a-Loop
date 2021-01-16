using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string InteractionText;
    public string ImpossibleText;

    [SerializeField]
    private float InteractionDownTime = 0.0f;
    [SerializeField]
    private string[] RequiredKeys;
    [SerializeField]
    private UnityEvent OnInteract;


    private float m_PreviousInteractTime = 0.0f;

    public bool CanInteract()
    {
        bool downTimeElapsed = Time.time > m_PreviousInteractTime + InteractionDownTime;
        return enabled && downTimeElapsed && RequiredKeys.All(x => Inventory.Instance.HasKey(x));
    }

    public void Interact()
    {
        if (CanInteract())
        {
            m_PreviousInteractTime = Time.time;
            foreach (string s in RequiredKeys)
            {
                Inventory.Instance.UseKey(s);
            }
            if (OnInteract != null)
            {
                OnInteract.Invoke();
            }
        }
    }
}
