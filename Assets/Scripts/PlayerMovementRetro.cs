using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerMovementRetro : PlayerMovement
{
    private bool isGrounded = false;

    private void OnCollisionEnter2D() => isGrounded = true;
    private void OnCollisionExit2D() => isGrounded = false;

    protected override void OnDash()
    {
        wantsToDash = false;

        if (!CanDash())
            return;

        Vector2 dashVelocity = new Vector2(moveInput.x, 1) * dashMultiplier;
        rb.velocity = dashVelocity;
    }

    protected override bool CanDash() => isGrounded;
}
