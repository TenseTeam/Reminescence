using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(Fade))]
public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;
    void Update()
    {
        if (GetComponent<VideoPlayer>().time == GetComponent<VideoPlayer>().clip.length)
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
