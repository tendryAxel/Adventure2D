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

        // TODO: next thing will be to separate the pick-up and open content child
        // that way we can open a window only if the open content is present
        AbstractContentManager contentManager = GetLastInteractable().GetComponent<AbstractContentManager>();

        if (contentManager != null)
        {
            playerInventoryContentManager.MoveHere(contentManager.GetContents().Last(), contentManager);
        }
    }
}
