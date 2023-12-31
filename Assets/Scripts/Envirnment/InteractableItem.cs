    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField] protected ItemBaseData m_Item;
    [SerializeField] protected int m_QuestIndex;
    [SerializeField] protected Color m_ColorHighlight;
    [SerializeField] protected float m_WidthHighlight;

    protected bool m_IsInteractable = true;
    protected GameObject m_Highlight;
    protected InteractionComponent m_PlayerInteraction;
    protected AudioSource m_AudioSource;

    protected bool m_InRange = false;

    protected void Start()
    {
        GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        m_AudioSource = GetComponent<AudioSource>();
    }

    protected void Update()
    {
        //interaction between item and player
        if (m_PlayerInteraction != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && m_InRange)
            {
                Interact(m_PlayerInteraction);
                m_IsInteractable = false;
                HighLight(false);
                m_PlayerInteraction = null;
            }
        }
    }

    /// <summary>
    /// Method used for call player interaction giving item information 
    /// </summary>
    /// <param name="interaction"></param>
    public void Interact(InteractionComponent interaction)
    {
        interaction.Interact(m_Item, m_QuestIndex, m_AudioSource);
    }

    /// <summary>
    /// graphic feedback for interactable item
    /// </summary>
    /// <param name="mode"></param>
    protected void HighLight(bool mode)
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
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out InteractionComponent player) && m_IsInteractable)
        {
            m_InRange = true;
            HighLight(true);
            m_PlayerInteraction = player;
            GameManager.instance.UIManager.SetActiveInteractIcon(true);
        }
    }

    /// <summary>
    /// feedback for exiting from item's area
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPlayer player) && m_IsInteractable)
        {
            if (m_IsInteractable)
            {
                m_InRange = false;
                HighLight(false);
                m_PlayerInteraction = null;
            }
            GameManager.instance.UIManager.SetActiveInteractIcon(false);
        }
    }
}
