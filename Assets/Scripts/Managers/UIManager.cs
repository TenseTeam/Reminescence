using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject m_PauseMenu;

    [Header("Interaction System")]
    [SerializeField] private GameObject m_ItemInteraction;
    [SerializeField] private Image m_ItemInteractionImage;
    [SerializeField] private TextMeshProUGUI m_ItemInteractionDescription; 
    [SerializeField] private Image m_InteractionIcon;
    [SerializeField] private KeyCode m_HideInteractionKey;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_INTERACTION, ShowInteractableItem);
        SetActiveObject(m_ItemInteraction);
        SetActiveObject(m_PauseMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ItemInteraction.activeInHierarchy && Input.GetKeyDown(m_HideInteractionKey))
        {
            SetActiveObject(m_ItemInteraction);
        }
    }

    private void SetActiveObject(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);
    }

    public void ShowInteractableItem(object[] param)
    {
        SetActiveObject(m_ItemInteraction);
        switch (((ItemBaseData)param[0]).Type)
        {
            case ItemType.Furniture:
                m_ItemInteractionImage.gameObject.SetActive(false);
                m_ItemInteractionDescription.gameObject.SetActive(true);
                m_ItemInteractionDescription.text = ((FornitureiteamData)param[0]).Description;
                break;
            case ItemType.NewsPaper:
                m_ItemInteractionImage.gameObject.SetActive(true);
                m_ItemInteractionImage.sprite = ((NewsPaperItemData)param[0]).UiImage;
                m_ItemInteractionDescription.gameObject.SetActive(true);
                m_ItemInteractionDescription.text = ((NewsPaperItemData)param[0]).Description;
                break;
            case ItemType.Frame:
                m_ItemInteractionImage.gameObject.SetActive(true);
                m_ItemInteractionImage.sprite = ((UiItemData)param[0]).UiImage;
                m_ItemInteractionDescription.gameObject.SetActive(false);
                break;
        }
    }
}
