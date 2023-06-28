using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FrameController : MonoBehaviour
{
    [SerializeField] private int m_SideQuestIndex;
    [SerializeField] private Sprite m_FullFrame;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_FRAME, ChangeTexture);
    }

    public void ChangeTexture(object[] parameters)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = m_FullFrame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_CHECK_SIDE_QUEST, m_SideQuestIndex);
    }
}
