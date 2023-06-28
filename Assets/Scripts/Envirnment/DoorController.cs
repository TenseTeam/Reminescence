using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class DoorController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_UNLOCK_DOOR, ThroughDoor);
    }

    public void ThroughDoor(object[] parameters)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Destroy(collider);
        Destroy(renderer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_END_LEVEL, m_NextScene);
    }
}