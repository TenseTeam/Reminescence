using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [System.Serializable]
    public struct Quest
    {
        [SerializeField] private bool[] m_SideQuest;
    }

    [SerializeField] private Quest[] m_QuestList;
    // Start is called before the first frame update

    /// <summary>
    /// Update the main quest with a new node unlocked
    /// </summary>
    public void UpdateQuest()
    {

    }

    /// <summary>
    /// Update the specified side quest with a new node unlocked
    /// </summary>
    /// <param name="index"></param>
    public void UpdateSideQuest(int index)
    {

    }

    /// <summary>
    /// Check if the main quest is completed
    /// </summary>
    /// <returns></returns>
    public bool CheckQuest()
    {
        return true;
    }

    /// <summary>
    /// Check if the specified side quest is completed
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool CheckSideQuest(int index)
    {
        return true;
    }
}