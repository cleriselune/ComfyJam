using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject[] possibleItems;
    GameObject itemToGive;
    bool hasInteracted = false;
    bool finishedInteraction = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable())
        {
            // interaction logic: get an order, list of items the npc wants
            if (Keyboard.current.eKey.wasPressedThisFrame && !hasInteracted)
            {
                Debug.Log("interacted");
                RandomizeOrder();

                hasInteracted = true;
            }

            if (Keyboard.current.eKey.wasPressedThisFrame && hasInteracted)
            {
                // give item to npc
                var inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                if (inventory == null)
                {
                    Debug.LogWarning("interactor does not have an inventory component");
                    return;
                }
                if (inventory.HasItem(itemToGive))
                {
                    Debug.Log("gave item: " + itemToGive.name);
                    inventory.RemoveItemFromInventory(itemToGive);
                    inventory.WriteInventoryToConsole();
                    finishedInteraction = true;
                } else
                {
                    Debug.Log("player does not have the item: " + itemToGive.name);
                }
                
            }

            if (finishedInteraction)
            {
                //Debug.Log("interaction finished");
                
            }

        }
    }

    bool isInteractable()
    {
        if (Vector3.Distance(NPC.transform.position, transform.position) < 3f)
        {
            //Debug.Log("interactable");
            return true;
        } return false;
        
    }

    void RandomizeOrder()
    {
        int randomIndex = Random.Range(0, possibleItems.Length);
        GameObject randomItem = possibleItems[randomIndex];
        Debug.Log("NPC wants: " + randomItem.name);
        itemToGive = randomItem;
    }

}
