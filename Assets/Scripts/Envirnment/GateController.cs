using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class GateController : InteractableItem
{
    [SerializeField] private int m_SideQuestIndex;
    private new void Start()
    {
        
    }

    private new void Update()
    {
        //interaction between item and player
        if (m_PlayerInteraction != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && m_InRange)
            {
                if (GameManager.instance.QuestManager.CheckSideQuest(m_SideQuestIndex))
                {
                    Interact();
                    m_IsInteractable = false;
                    HighLight(false);
                    m_PlayerInteraction = null;
                }
            }
        }
    }

    public void Interact()
    {
        ThroughGate();
    }

    private void ThroughGate()
    {
        GetComponent<BoxCollider2D>().enabled = false; 
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false; 
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;

    }
}
