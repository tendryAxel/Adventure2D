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

    // Functions references
    private List<ActionInputContext> moveActions = new();
    private List<ActionInputContext> moveActionsCancel = new();

    void OnEnable()
    {
        move.action.Enable();
        move.action.performed += MoveActions;
        move.action.canceled += MoveActionsCancel;
    }

    void OnDisable()
    {
        move.action.performed -= MoveActions;
        move.action.canceled -= MoveActionsCancel;
        moveActions.Clear();
        moveActionsCancel.Clear();
    }

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
}
