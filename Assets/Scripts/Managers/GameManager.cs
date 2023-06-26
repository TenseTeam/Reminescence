using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private UIManager m_UIManager;
    private QuestManager m_QuestManager;
    private EventManager m_EventManager;
    // Start is called before the first frame update
    void Start()
    {
        m_UIManager = GetComponentInChildren<UIManager>();
        m_QuestManager = GetComponentInChildren<QuestManager>();
        m_EventManager = Factory.CreateEvenetManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
