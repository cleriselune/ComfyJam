using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] items = new GameObject[0];

    public void AddItemToInventory(GameObject item)
    {
        items = items.Append(item).ToArray();
        item.SetActive(false);
        Debug.Log("item added to inventory: " + item.name);
    }

    public void WriteInventoryToConsole()
    {
        Debug.Log("inventory contains: " + items.Length + " items");
    }

    public bool HasItem(GameObject item)
    {
        return items.Contains(item);
    }

    public void RemoveItemFromInventory(GameObject item)
    {
        if (HasItem(item))
        {
            items = items.Where(i => i != item).ToArray();
            Debug.Log("item removed from inventory: " + item.name);
        }
        else
        {
            Debug.LogWarning("item not found in inventory: " + item.name);
        }
    }

}
