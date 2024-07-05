using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Body;
    public float x;
    public float y;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Body.velocity = new Vector2(x * Speed, y * Speed);
        if (Body.velocity.x > 0)
            spriteRenderer.flipX = true;
        else if (Body.velocity.x < 0)
            spriteRenderer.flipX = false;
        animator.SetFloat("xVelocity", Mathf.Abs(Body.velocity.magnitude));
    }
}
