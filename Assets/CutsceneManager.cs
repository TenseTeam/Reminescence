using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector m_PlayableDirector;
    [SerializeField] private int m_NextScene;

    private void Start()
    {
        m_PlayableDirector = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (m_PlayableDirector.state == PlayState.Paused)
        {
            GetComponent<Fade>().DoFadeIn();
            StartCoroutine(Load());
        }
    }


    private IEnumerator Load()
    {
        yield return new WaitForSeconds(GetComponent<Fade>().FadeDuration);
        SceneManager.LoadScene(m_NextScene);
    }
}
