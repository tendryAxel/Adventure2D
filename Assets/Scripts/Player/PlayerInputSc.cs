using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ActionInputContext = System.Action<UnityEngine.InputSystem.InputAction.CallbackContext>;

public class PlayerInputSc : MonoBehaviour
{
    // Actions references
    [SerializeField]
    private InputActionReference move;
    [SerializeField]
    private InputActionReference interactActionReference;

    // Functions references
    private List<ActionInputContext> moveActions = new();
    private List<ActionInputContext> moveActionsCancel = new();
    private List<ActionInputContext> interactActions = new();

    void OnEnable()
    {
        move.action.Enable();
        move.action.performed += MoveActions;
        move.action.canceled += MoveActionsCancel;

        interactActionReference.action.Enable();
        interactActionReference.action.performed += InteractAtcions;
    }

    void OnDisable()
    {
        move.action.performed -= MoveActions;
        move.action.canceled -= MoveActionsCancel;
        moveActions.Clear();
        moveActionsCancel.Clear();

        interactActionReference.action.performed -= InteractAtcions;
        interactActions.Clear();
    }

    // Move Action
    void MoveActions(InputAction.CallbackContext context)
    {
        foreach (ActionInputContext action in moveActions)
        {
            action(context);
        }
    }

    void MoveActionsCancel(InputAction.CallbackContext context)
    {
        foreach (ActionInputContext action in moveActionsCancel)
        {
            action(context);
        }
    }

    public void RegisterMoveActions(ActionInputContext action)
    {
        moveActions.Add(action);
    }

    public void RegisterMoveActionsCancel(ActionInputContext action)
    {
        moveActionsCancel.Add(action);
    }

    // Interact Action
    void InteractAtcions(InputAction.CallbackContext context)
    {
        foreach (ActionInputContext action in interactActions)
        {
            action(context);
        }
    }

    public void RegisterInteractActions(ActionInputContext action)
    {
        interactActions.Add(action);
    }
}
