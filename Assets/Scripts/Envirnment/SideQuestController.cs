using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SideQuestController : MonoBehaviour
{
    [SerializeField] private int m_SideQuestIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_CHECK_SIDE_QUEST, m_SideQuestIndex);
    }
}
