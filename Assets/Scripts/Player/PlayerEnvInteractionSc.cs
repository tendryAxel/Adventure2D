using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnvInteractionSc : MonoBehaviour
{
    private List<Collider2D> collisions = new();

    [SerializeField]
    private Texture2D interactionImage;

    [SerializeField]
    private string interactionText;
    
    // Inputs
    [SerializeField]
    private PlayerInputSc playerInputSc;

    [SerializeField]
    private PlayerInventoryContentManager playerInventoryContentManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Chest") && !collision.CompareTag("Item"))
        {
            return;
        }

        InteracableItemInfo info = collision.GetComponent<AbstractContentManager>()?.GetInfo();

        if (info == null)
        {
            Debug.LogWarning("Interaction with " + collision + " that doesn't have any InteracableItem script");
        }

        collisions.Add(collision);
        Debug.Log("In range of interactable item " + collision);
        NotifyInteractInterface();
    }

    ItemData GetItemInfo(Collider2D item)
    {
        return item.GetComponent<AbstractContentManager>().GetInfo().GetInfo();
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

        ItemData lastInteractableInfo = GetLastInteractableData();
        
        interactionText = lastInteractableInfo.ItemName();
        interactionImage = lastInteractableInfo.ItemImage();
        MainHUDManagement.GetInstance().SetInteractionItem(interactionText, interactionImage);
    }

    Collider2D GetLastInteractable()
    {
        return collisions[collisions.Count - 1];
    }

    ItemData GetLastInteractableData()
    {
        return GetItemInfo(GetLastInteractable());
    }

    void Start()
    {
        playerInputSc.RegisterInteractActions(InteractionInputAction);
    }

    void InteractionInputAction(InputAction.CallbackContext context)
    {
        if (collisions.Count == 0)
        {
            return;
        }

        AbstractContentManager contentManager = GetLastInteractable().GetComponent<AbstractContentManager>();

        switch (contentManager)
        {
            case ChestContentManagement chestContentManagement:
                {
                    playerInventoryContentManager.MoveHere(chestContentManagement.GetSelectedItem(), contentManager);
                    break;
                }
            default:
                {
                    playerInventoryContentManager.MoveHere(contentManager.GetContents().Last(), contentManager);
                    break;
                }
            case null: 
                {
                    Debug.LogWarning("Content manager is null for " + GetLastInteractable());
                    break;
                }
        }
    }
}
