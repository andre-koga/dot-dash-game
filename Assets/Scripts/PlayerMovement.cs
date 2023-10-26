using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    /// <summary>
    /// WASD inputs.
    /// </summary>
    private Vector2 moveInput;

    /// <summary>
    /// True if pressed X. False otherwise.
    /// </summary>
    private bool wantsToDash;

    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected Vector2 dashMultiplier = new Vector2(25f, 20f);
    [SerializeField, Range(0f, 1f)] protected float speedUpLerp = 0.3f;
    [SerializeField, Range(0f, 1f)] protected float slowDownLerp = 0.1f;

    protected virtual void Start() => rb = GetComponent<Rigidbody2D>();

    protected virtual void Update() => InputDetection();

    protected virtual void FixedUpdate()
    {
        // Dash in the direction of WASD keys when press X.
        if (wantsToDash) OnDash();
        // Horizontal movement of player. Lerp between previous velocity and new velocity.
        else OnMove();
    }

    /// <summary>
    /// Dash in the direction of WASD keys when press X.
    /// </summary>
    protected virtual void OnDash()
    {
        wantsToDash = false;

        if (!CanDash())
            return;

        Vector2 dashVelocity = moveInput == Vector2.zero ? Vector2.up : moveInput * dashMultiplier;
        rb.velocity = dashVelocity;
    }

    /// <summary>
    /// Check if player can dash.
    /// </summary>
    /// <returns>True if player can dash. False otherwise.</returns>
    protected virtual bool CanDash() => true;

    /// <summary>
    /// Horizontal movement of player. Lerp between previous velocity and new velocity.
    /// </summary>
    protected virtual void OnMove()
    {
        bool wouldSlowDown = rb.velocity.x * moveInput.x > 0 && Mathf.Abs(rb.velocity.x) > Mathf.Abs(moveInput.x * moveSpeed);

        Vector2 targetVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, wouldSlowDown ? slowDownLerp : speedUpLerp);
    }

    /// <summary>
    /// Detects player input.
    /// </summary>
    private void InputDetection()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.X)) wantsToDash = true;
    }
}