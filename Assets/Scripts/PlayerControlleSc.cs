using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlleSc : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Inputs
    [SerializeField]
    private PlayerInputSc playerInputSc;

    // Physic statistics
    [SerializeField]
    private float speed = 10;

    // Physic properties
    private Vector2 velocity = Vector2.zero;

    // Animation
    [SerializeField]
    private Animator animator;

    void ChangeVelocity(InputAction.CallbackContext context)
    {
        Vector2 input = context.action.ReadValue<Vector2>();
        velocity = input * speed;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        playerInputSc.RegisterMoveActions(ChangeVelocity);
        playerInputSc.RegisterMoveActionsCancel(ChangeVelocity);
    }

    void Update()
    {
        animator.SetFloat("speed", velocity.magnitude);
        rb2d.linearVelocity = velocity;
    }
}
