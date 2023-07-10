using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Interaction System")]
    [SerializeField] private GameObject m_ItemInteraction;
    [SerializeField] private Image m_ItemInteractionImage;
    [SerializeField] private TextMeshProUGUI m_ItemInteractionDescription; 
    [SerializeField] private TextMeshProUGUI m_ItemInteractionTitle; 
    [SerializeField] private GameObject m_InteractionIcon;
    [SerializeField] private KeyCode m_HideInteractionKey;
    [SerializeField] private KeyCode m_ShowHidePauseMenuKey;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_INTERACTION, ShowInteractableItem);
        SetActiveObject(m_ItemInteraction, false);
        SetActiveObject(m_InteractionIcon, false);
        SetActiveObject(GameManager.instance.MenuManager.Menu, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ItemInteraction.activeSelf && Input.GetKeyDown(m_HideInteractionKey))
        {
            SetActiveObject(m_ItemInteraction, false);
            GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_STOP_INTERACTION, false);
        }
        if (Input.GetKeyDown(m_ShowHidePauseMenuKey)) 
        {
            ShowHideMenu();
        }
    }

    private void SetActiveObject(GameObject obj, bool value)
    {
        obj.SetActive(value);
    }

    public void ShowHideMenu()
    {
        if (Time.timeScale == 1f)
        {
            SetActiveObject(GameManager.instance.MenuManager.Menu, true);
            Time.timeScale = 0f;
        }
        else
        {
            SetActiveObject(GameManager.instance.MenuManager.Menu, false);
            Time.timeScale = 1f;
        }
    }

    public void ShowInteractableItem(object[] param)
    {
        switch (((ItemBaseData)param[0]).Type)
        {
            case ItemType.Furniture:
                m_ItemInteractionImage.gameObject.SetActive(false);
                m_ItemInteractionDescription.gameObject.SetActive(true);
                m_ItemInteractionTitle.gameObject.SetActive(false);
                m_ItemInteractionDescription.text = ((FornitureiteamData)param[0]).Description;
                break;
            case ItemType.NewsPaper:
                m_ItemInteractionImage.gameObject.SetActive(true);
                m_ItemInteractionImage.sprite = ((NewsPaperItemData)param[0]).UiImage;
                m_ItemInteractionDescription.gameObject.SetActive(true);
                m_ItemInteractionDescription.text = ((NewsPaperItemData)param[0]).Description;
                m_ItemInteractionTitle.gameObject.SetActive(true);
                m_ItemInteractionTitle.text = ((NewsPaperItemData)param[0]).Title;
                break;
            case ItemType.Frame:
                m_ItemInteractionImage.gameObject.SetActive(true);
                m_ItemInteractionImage.sprite = ((UiItemData)param[0]).UiImage;
                m_ItemInteractionDescription.gameObject.SetActive(false);
                m_ItemInteractionTitle.gameObject.SetActive(false);
                break;
        }
        SetActiveObject(m_ItemInteraction, true);
        SetActiveObject(m_InteractionIcon, false);
    }

    public void SetActiveInteractIcon(bool value)
    {
        SetActiveObject(m_InteractionIcon, value);
    }
}
