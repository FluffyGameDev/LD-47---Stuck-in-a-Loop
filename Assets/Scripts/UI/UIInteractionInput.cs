using UnityEngine;
using UnityEngine.UI;

public class UIInteractionInput : MonoBehaviour
{
    [SerializeField]
    private InteractionInitiator WatchedInteractionInitiator = null;
    [SerializeField]
    private Color ActionPossibleColor;
    [SerializeField]
    private Color ActionImpossibleColor;

    [SerializeField]
    private Text TextField;
    [SerializeField]
    private Text FrontTextField;

    void Update()
    {
        string text = "";
        if (WatchedInteractionInitiator != null)
        {
            Interactable interactableCandidate = WatchedInteractionInitiator.GetInteractableCandidate();
            if (interactableCandidate != null && interactableCandidate.enabled && interactableCandidate.gameObject.activeSelf)
            {
                if (interactableCandidate.CanInteract())
                {
                    FrontTextField.color = ActionPossibleColor;
                    text = interactableCandidate.InteractionText;
                }
                else
                {
                    FrontTextField.color = ActionImpossibleColor;
                    text = interactableCandidate.ImpossibleText;
                }
            }
        }

        TextField.text = text;
        FrontTextField.text = text;
    }
}
