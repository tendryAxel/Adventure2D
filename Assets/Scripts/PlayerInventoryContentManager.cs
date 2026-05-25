using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryContentManager : AbstractContentManager
{
    [SerializeField]
    private PlayerInputSc playerInput;

    public AbstractContentManager otherContentActuallyInteracting;

    void Start()
    {
        playerInput.RegisterInteractActions(DoInteractAction);
    }

    void DoInteractAction(InputAction.CallbackContext context)
    {
        ChestContentData otherContent = otherContentActuallyInteracting.GetContentData();
        MoveTo(
            otherContent.GetContents()[0],
            otherContent
        );
    }
}
