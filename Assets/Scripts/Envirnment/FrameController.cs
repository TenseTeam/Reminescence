using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class FrameController : MonoBehaviour
{
    [SerializeField] private int m_SideQuestIndex;
    [SerializeField] private Sprite m_FullFrame;

    /// <summary>
    /// change gameObject texture when method is triggered
    /// </summary>
    /// <param name="parameters"></param>
    public void ChangeTexture()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = m_FullFrame;
    }

    /// <summary>
    /// check if player is in area, if it is check if its side quest is done
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.QuestManager.CheckSideQuest(m_SideQuestIndex))
        {
            ChangeTexture();
        }
    }
}
