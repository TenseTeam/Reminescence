using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StairController : MonoBehaviour
{
    [SerializeField] private StairController m_OtherPosition;
    bool m_IsArriving = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player) && m_IsArriving == false)
        {
            player.transform.position = m_OtherPosition.transform.position;
            m_OtherPosition.m_IsArriving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_IsArriving = false;
    }
}
