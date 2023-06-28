    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemBaseData m_Item;
    [SerializeField] private int m_QuestIndex;
    [SerializeField] private Color m_ColorHighlight;
    [SerializeField] private float m_WidthHighlight;

    private bool m_IsInteractable = true;
    private GameObject m_Highlight;

    private bool m_InRange;

    /// <summary>
    /// Method used for call player interaction giving item information 
    /// </summary>
    /// <param name="interaction"></param>
    public void Interact(InteractionComponent interaction)
    {
        interaction.Interact(m_Item, m_QuestIndex);
    }

    /// <summary>
    /// graphic feedback for interactable item
    /// </summary>
    /// <param name="mode"></param>
    private void HighLight(bool mode)
    {
        if (mode)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            m_Highlight = Factory.CreateHighlightSprite(renderer, m_ColorHighlight, m_WidthHighlight);
        }
        else
        {
            Destroy(m_Highlight);
        }
    }

    /// <summary>
    /// feedback for entering in item's area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            m_InRange = true;
            HighLight(true);
            //GameManager.instance.UIManager.InteractUIEnable();
        }
    }

    /// <summary>
    /// interaction between item and player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractionComponent interaction))
        {
            if (Input.GetKeyDown(KeyCode.E) && m_InRange)
            {
                Interact(interaction);
                m_IsInteractable = false;
                //GameManager.instance.UIManager.InteractUIDisable();
            }
        }
    }

    /// <summary>
    /// feedback for exiting from item's area
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            m_InRange = false;
            if (m_IsInteractable)
                HighLight(false);
            //GameManager.instance.UIManager.InteractUIDisable();
        }
    }
}
