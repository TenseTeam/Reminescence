using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StairController : MonoBehaviour
{
    [SerializeField] private Transform m_OtherPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player))
        {
            player.gameObject.transform.position = m_OtherPosition.position;
        }
    }
}
