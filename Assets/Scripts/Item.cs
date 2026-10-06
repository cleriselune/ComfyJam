using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    void IInteractable.Interact(GameObject interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("interactor does not have an inventory component");
            return;
        }
        Debug.Log("interacted with item: " + gameObject.name);
        inventory.AddItemToInventory(gameObject);
        inventory.WriteInventoryToConsole();
    }


}
