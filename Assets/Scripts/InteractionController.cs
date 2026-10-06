using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact(GameObject interactor);
}

public class InteractionController : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    float interactionDistance = 5f;
    IInteractable currentInteractable;

    public void Start()
    {
        mainCam = Camera.main;
    }

    public void Update()
    {
        UpdateInteraction();

        CheckForInteractionInput();
    }

    void UpdateInteraction()
    {
        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // center of the screen; viewport is the whole area player can see

        Physics.Raycast(ray, out var hit, interactionDistance);

        currentInteractable = hit.collider?.GetComponent<IInteractable>();

    }

    void CheckForInteractionInput()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame && currentInteractable != null)
        {
            currentInteractable.Interact(gameObject);
        }

    }
}
