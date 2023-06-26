using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(InteractionComponent))]
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

    // Update is called once per frame
    void Update()
    {
        m_Movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
