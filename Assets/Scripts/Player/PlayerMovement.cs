using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rd2D;
    private Vector2 moveDirection;

    void Awake()
    {
        player = GetComponent<Player>();
        actions = new PlayerActions();
        rd2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        ReadMovement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (player.Stats.Health <= 0) return;
        rd2D.MovePosition(rd2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }
        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    void OnEnable()
    {
        actions.Enable();
    }

    void OnDisabled()
    {
        actions.Disable();
    }
}
