using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject m_BaseMenu;
    [SerializeField] private GameObject m_OptionMenu;
    [SerializeField] private GameObject m_CreditsMenu;

    private void Start()
    {
        ChangeToBaseMenu();
    }

    public void Play(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    #region menu navigation
    public void ChangeToBaseMenu()
    {
        m_BaseMenu.SetActive(true);
        m_OptionMenu.SetActive(false);
        m_CreditsMenu.SetActive(false);
    }

    public void ChangeToOptionsMenu()
    {
        m_BaseMenu.SetActive(false);
        m_OptionMenu.SetActive(true);
        m_CreditsMenu.SetActive(false);
    }

    public void ChangeToCreditsMenu()
    {
        m_BaseMenu.SetActive(false);
        m_OptionMenu.SetActive(false);
        m_CreditsMenu.SetActive(true);
    }
    #endregion
}
