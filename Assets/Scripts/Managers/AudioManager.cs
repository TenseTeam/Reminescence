using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private AudioMixerGroup m_MasterGroup;
    [SerializeField] private AudioMixerGroup m_MusicGroup;
    [SerializeField] private AudioMixerGroup m_EffectsGroup;
    public AudioMixer AudioMixer { get => m_AudioMixer;}
    private AudioSource m_OSTAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_INTERACTION, PlayAudioClip);
        m_OSTAudioSource = GetComponent<AudioSource>();
        m_OSTAudioSource.Play();
    }

    public void PlayAudioClip(object[] param)
    {
        ((AudioSource)param[2]).loop = false;
        ((AudioSource)param[2]).outputAudioMixerGroup = m_EffectsGroup;
        ((AudioSource)param[2]).clip = ((ItemBaseData)param[0]).AudioSFX;
        ((AudioSource)param[2]).Play();
    }
}
