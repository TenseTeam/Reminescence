using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float m_MovementSpeed = 0f;
    private Rigidbody2D m_RigidBody;
    private SpriteRenderer m_Sprite;
    private Animator m_Animator;
    private bool m_IsInteracting = false;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Sprite = GetComponent<SpriteRenderer>();
        GameManager.instance.EventManager.Register(Constants.EVENT_INTERACTION, ManageFreeze);
        GameManager.instance.EventManager.Register(Constants.EVENT_STOP_INTERACTION, ManageFreeze);
    }

    /// <summary>
    /// top-down movement method
    /// </summary>
    /// <param name="vertical"></param>
    /// <param name="horizontal"></param>
    public void Move(float vertical, float horizontal)
    {
        if (!m_IsInteracting)
        {
            m_RigidBody.velocity = (Vector2.up * vertical + Vector2.right * horizontal) * (m_MovementSpeed * 100) * Time.deltaTime;

            ManageAnimation();
        }
    }

    public void ManageFreeze(object[] param)
    {
        m_IsInteracting = !m_IsInteracting;
    }
        
    /// <summary>
    /// manage animation for to right/left, up and down
    /// </summary>
    private void ManageAnimation()
    {
        if (m_RigidBody.velocity.x > 0.001f)
        {
            m_Animator.SetBool("isMovingRight", true);
            m_Animator.SetBool("isMovingLeft", false);
            m_Animator.SetBool("isMovingUp", false);
            m_Animator.SetBool("isMovingDown", false);
        }
        else if (m_RigidBody.velocity.x < -0.001f)
        {
            m_Animator.SetBool("isMovingLeft", true);
            m_Animator.SetBool("isMovingRight", false);
            m_Animator.SetBool("isMovingUp", false);
            m_Animator.SetBool("isMovingDown", false);
        }
        else if (m_RigidBody.velocity.y > 0.001f)
        {
            m_Animator.SetBool("isMovingUp", true);
            m_Animator.SetBool("isMovingLeft", false);
            m_Animator.SetBool("isMovingRight", false);
            m_Animator.SetBool("isMovingDown", false);
        }
        else if (m_RigidBody.velocity.y < -0.001f)
        {
            m_Animator.SetBool("isMovingDown", true);
            m_Animator.SetBool("isMovingUp", false);
            m_Animator.SetBool("isMovingLeft", false);
            m_Animator.SetBool("isMovingRight", false);
        }
        else
        {
            m_Animator.SetBool("isMovingLeft", false);
            m_Animator.SetBool("isMovingRight", false);
            m_Animator.SetBool("isMovingUp", false);
            m_Animator.SetBool("isMovingDown", false);
        }
    }
}
