using Unity.Collections;
using UnityEngine;

public class InteractionInitiator : MonoBehaviour
{
    [SerializeField]
    private float MaxInteractDistance = 1.0f;

    [ReadOnly]
    [SerializeField]
    private Interactable InteractableCandidate = null;

    public Interactable GetInteractableCandidate()
    {
        return InteractableCandidate;
    }

    void Update()
    {
        if (InteractableCandidate != null && Input.GetButtonDown("Interact"))
        {
            InteractableCandidate.Interact();
        }
    }

    void FixedUpdate()
    {
        InteractableCandidate = null;

        int layerMask = 0;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxInteractDistance, layerMask))
        {
            InteractableCandidate = hit.collider.GetComponent<Interactable>();
        }
    }
}
