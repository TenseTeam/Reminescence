using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private UIManager m_UIManager;
    public UIManager UIManager { get => m_UIManager;}

    private EventManager m_EventManager;
    public EventManager EventManager { get => m_EventManager;}

    private QuestManager m_QuestManager;
    public QuestManager QuestManager { get => m_QuestManager; }

    private DialogueManager m_DialogueManager;
    public DialogueManager DialogueManager { get => m_DialogueManager; }
    
    private AudioManager m_AudioManager;
    public AudioManager AudioManager { get => m_AudioManager; }

    private MenuManager m_MenuManager;
    public MenuManager MenuManager { get => m_MenuManager; }


    // Start is called before the first frame update
    void OnEnable()
    {
        m_UIManager = GetComponentInChildren<UIManager>();
        m_DialogueManager = GetComponentInChildren<DialogueManager>();
        m_AudioManager = GetComponentInChildren<AudioManager>();
        m_QuestManager = GetComponentInChildren<QuestManager>();
        m_MenuManager = GetComponentInChildren<MenuManager>();
        m_EventManager = Factory.CreateEvenetManager();
    }

    private void Start()
    {
        instance.EventManager.Register(Constants.EVENT_END_LEVEL, LevelCompleted);
    }

    /// <summary>
    /// change scene with the index in parameters at position 1 (see class diagram)
    /// </summary>
    /// <param name="parameters"></param>
    public void LevelCompleted(object[] parameters)
    {
        SceneManager.LoadScene((int)parameters[0]);
    }
}
