using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Move(float vertical, float horizontal)
    {
        rb.velocity = (Vector2.up * vertical + Vector2.right * horizontal) * (m_MovementSpeed * 10) * Time.deltaTime;

        if (Mathf.Abs(rb.velocity.x) > 0.001f)
            anim.SetBool("isMovingRL", true);
        else if (rb.velocity.y > 0.001f)
            anim.SetBool("isMovingUp", true);
        else if (rb.velocity.y < 0.001f)
            anim.SetBool("isMovingDown", true);
        else
        {
            anim.SetBool("isMovingRL", false);
            anim.SetBool("isMovingUp", false);
            anim.SetBool("isMovingDown", false);
        }


        sprite.flipX = rb.velocity.x < 0;
    }
}
