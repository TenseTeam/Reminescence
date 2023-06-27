using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int m_NextLevel;

    private UIManager m_UIManager;
    public UIManager UIManager { get => m_UIManager;}

    private QuestManager m_QuestManager;
    public QuestManager QuestManager { get => m_QuestManager;}

    private EventManager m_EventManager;
    public EventManager EventManager { get => m_EventManager;}


    // Start is called before the first frame update
    void OnEnable()
    {
        m_UIManager = GetComponentInChildren<UIManager>();
        m_QuestManager = GetComponentInChildren<QuestManager>();
        m_EventManager = Factory.CreateEvenetManager();
    }

    private void Start()
    {
        instance.EventManager.Register(Constants.EVENT_CHANGE_SCENE, LevelCompleted);
    }

    public void LevelCompleted(object[] parameters)
    {
        SceneManager.LoadScene((int)parameters[0]);
    }
}
