using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEnvInteractionSc : MonoBehaviour
{
    private List<Collider2D> collisions = new();

    [SerializeField]
    private Texture2D interactionImage;

    [SerializeField]
    private string interactionText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Chest") && !collision.CompareTag("Item"))
        {
            return;
        }

        if (!collision.GetComponent<InteracableItem>())
        {
            Debug.LogWarning("Interaction with " + collision + " that doesn't have any InteracableItem script");
        }

        collisions.Add(collision);
        Debug.Log("In range of interactable item " + collision);
        NotifyInteractInterface();
    }

    ItemData GetItemInfo(Collider2D item)
    {
        return item.GetComponent<InteracableItem>().GetInfo();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collisions.Remove(collision);
        NotifyInteractInterface();
    }

    void NotifyInteractInterface()
    {
        if (collisions.Count == 0)
        {
            MainHUDManagement.GetInstance().SetInteractionItem(null, null);
            return;
        }

        Collider2D lastInteractable = collisions[collisions.Count - 1];
        ItemData lastInteractableInfo = GetItemInfo(lastInteractable);
        
        interactionText = lastInteractableInfo.ItemName();
        interactionImage = lastInteractableInfo.ItemImage();
        MainHUDManagement.GetInstance().SetInteractionItem(interactionText, interactionImage);
    }
}
