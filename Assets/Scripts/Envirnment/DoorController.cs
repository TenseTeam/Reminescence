using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DoorController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_CHECK_QUEST, m_NextScene);
    }
}