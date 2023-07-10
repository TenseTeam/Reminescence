using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Fade))]
public class MemoryController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
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
