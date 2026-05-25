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
        MoveTo(
            otherContentActuallyInteracting.GetContents()[0],
            otherContentActuallyInteracting
        );
    }
}
