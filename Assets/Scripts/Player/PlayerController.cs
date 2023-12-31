using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour, IPlayer
{
    private MovementComponent m_Movement;
    private InteractionComponent m_Interaction;
    // Start is called before the first frame update
    void Start()
    {
        m_Movement = GetComponent<MovementComponent>();
        m_Interaction = GetComponent<InteractionComponent>();
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        m_Movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
