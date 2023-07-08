using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
public class RadioController : InteractableItem
{
    private AudioClip m_AudioClipLoop;
    private AudioMixerGroup m_AudioGroupLoop;
    protected new void Start()
    {
        base.Start();
        m_AudioSource.loop = true;
        m_AudioClipLoop = m_AudioSource.clip;
        m_AudioGroupLoop = m_AudioSource.outputAudioMixerGroup;
    }

    protected new void Update()
    {
        //interaction between item and player
        if (m_PlayerInteraction != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && m_InRange)
            {
                Interact(m_PlayerInteraction);
                m_IsInteractable = false;
                HighLight(false);
                m_PlayerInteraction = null;
            }
        }

        //check if the actual clip is in running and if the actual clip differs from the loop clip
        if(!m_AudioSource.isPlaying && m_AudioSource.clip != m_AudioClipLoop)
        {
            m_AudioSource.loop = true;
            m_AudioSource.clip = m_AudioClipLoop;
            m_AudioSource.outputAudioMixerGroup = m_AudioGroupLoop;
        }
    }
}

//m_AudioSource.isPlaying