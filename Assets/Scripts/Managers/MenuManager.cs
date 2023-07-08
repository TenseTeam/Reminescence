using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject m_Menu;
    [SerializeField] private GameObject m_BaseMenu;
    [SerializeField] private GameObject m_OptionMenu;
    [SerializeField] private GameObject m_CreditsMenu;
    [SerializeField] private Sprite MusicCheckBoxOff;
    [SerializeField] private Sprite MusicCheckBoxOn;

    public Slider MasterSlider, MusicSlider, EffectsSlider;
    private bool activeMusic = true;
    public Image MusicCheckBox;


    public GameObject Menu { get => m_Menu;}

    private void Start()
    {
        ChangeToBaseMenu();
        MusicCheckBox.color = Color.cyan;
        SetSliderSettings(MasterSlider, "VolumeMaster");
        SetSliderSettings(MusicSlider, "VolumeMusic");
        SetSliderSettings(EffectsSlider, "VolumeSFX");
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
        GameManager.instance.UIManager.ShowHideMenu();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #region audio
    //public void SetMasterVolume(float volume)
    //{
    //    m_AudioMixer.SetFloat("VolumeMaster", volume);
    //}

    //public void SetMusicVolume(float volume)
    //{
    //    m_AudioMixer.SetFloat("VolumeMusic", volume);
    //}

    //public void SetSFXVolume(float volume)
    //{
    //    m_AudioMixer.SetFloat("VolumeSFX", volume);
    //}
    #endregion

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


    /// <summary>
    /// Changes values of the audio mixer's groups by using sliders
    /// </summary>
    public void SetVolume()
    {
        SetAudioLevel(MasterSlider, "VolumeMaster", "VolumeMaster");
        SetAudioLevel(MusicSlider, "VolumeMusic", "VolumeMusic");
        SetAudioLevel(EffectsSlider, "VolumeSFX", "VolumeSFX");
    }

    /// <summary>
    /// toggle music in game and changes color of a chekbox
    /// </summary>
    public void ToggleMusic()
    {
        if (activeMusic)
        {
            GameManager.instance.AudioManager.AudioMixer.SetFloat("VolumeMaster", 0);
            MusicCheckBox.sprite = MusicCheckBoxOn;
            activeMusic = !activeMusic;
            return;
        }
        if (!activeMusic)
        {
            GameManager.instance.AudioManager.AudioMixer.SetFloat("VolumeMaster", -80);
            MusicCheckBox.sprite = MusicCheckBoxOff;
            activeMusic = !activeMusic;
            return;
        }
    }

    /// <summary>
    /// set the slider value to 1
    /// </summary>
    /// <param name="slider"></param>
    /// <param name="key"></param>
    private void SetSliderSettings(Slider slider, string key)
    {
        slider.value = PlayerPrefs.GetFloat(key, 1f);
    }

    /// <summary>
    /// saves the audio slider in the PlayerPrefs and perform the actual volume changing
    /// </summary>
    /// <param name="slider"></param>
    /// <param name="key"> string name used as key for the PlayerPrefs</param>
    /// <param name="groupName">Audio Mixer group name</param>
    private void SetAudioLevel(Slider slider, string key, string groupName)
    {
        GameManager.instance.AudioManager.AudioMixer.SetFloat(groupName, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.SetFloat(key, slider.value);
    }
}
