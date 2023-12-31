using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static QuestManager;

public class QuestManager : MonoBehaviour
{
    [System.Serializable]
    public struct Quest
    {
        [SerializeField] public bool[] m_SideQuest;
    }

    [SerializeField] private Quest[] m_QuestList;
    // Start is called before the first frame update

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_INTERACTION, UpdateQuest);
    }

    /// <summary>
    /// Update the main quest with a new node unlocked
    /// </summary>
    /// <param name="parameters"></param>
    public void UpdateQuest(object[] parameters)
    {
        //is need the index of the quest list, it is incapsulated in "parameters" at position 1 (see attached class diagram)
        if(m_QuestList[(int)parameters[1]].m_SideQuest.Length > 1)
            UpdateSideQuest(parameters);
        else
            m_QuestList[(int)parameters[1]].m_SideQuest[0] = true;

        CheckQuest();
    }

    /// <summary>
    /// Update the specified side quest with a new node unlocked
    /// </summary>
    /// <param name="parameters"></param>
    private void UpdateSideQuest(object[] parameters)
    {
        //is need the index of the quest list, it is incapsulated in "parameters" at position 1 (see attached class diagram)
        bool founded = false;
        int i = 0;
        while (founded != i < m_QuestList[(int)parameters[1]].m_SideQuest.Length)
        {
            if(m_QuestList[(int)parameters[1]].m_SideQuest[i] == false)
            {
                m_QuestList[(int)parameters[1]].m_SideQuest[i] = true;
                founded = true;
            }
            else
                i++;
        }
    }

    /// <summary>
    /// Check if the main quest is completed and if it is unlock door
    /// </summary>
    public void CheckQuest()
    {
        bool checkVerified = true;
        foreach (Quest quest in m_QuestList)
        {
            bool breaked = false;
            for(int i = 0; i< quest.m_SideQuest.Length; i++)
            {
                if (quest.m_SideQuest[i] == false)
                {
                    breaked = true;
                    checkVerified = false;
                    break;
                }
            }
            if(breaked) break;
        }

        if (checkVerified)
            GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_UNLOCK_DOOR);
    }

    /// <summary>
    /// Check if the specified side quest is completed
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool CheckSideQuest(int index)
    {
        //is needed the index of the quest list, it is incapsulated in "parameters" at position 1 (see attached class diagram)
        bool checkVerified = true;
        for (int i = 0; i < m_QuestList[index].m_SideQuest.Length; i++)
        {
            if (m_QuestList[index].m_SideQuest[i] == false)
            {
                checkVerified = false;
                break;
            }
        }
        return checkVerified;
    }
}