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
        double time = GetComponent<VideoPlayer>().time;
        double lenght = GetComponent<VideoPlayer>().clip.length;
        if (time >= lenght - 0.5)
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
