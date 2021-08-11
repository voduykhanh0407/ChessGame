using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager Instance;

    [SerializeField] private GameObject loadSceneCanvas;
    [SerializeField] private Image progressBar;

    AsyncOperation operation;
    private float progress;

    private float t = 0f;
    private float timeToLoad = 5f;

    private float max = 1f;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator LoadingProgressBar()
    {
        yield return new WaitForSeconds(0.5f);
        if(operation.progress > 0.1f)
        {
            StartCoroutine(LoadingProgressBarFake());
            //Debug.Log("Fake");
        }
        else
        {
            StartCoroutine(LoadingProgressBarReal());
            //Debug.Log("Real");
        }
    }

    public IEnumerator LoadingProgressBarFake()
    {
        t = 0;
        progressBar.fillAmount = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / timeToLoad;
            progressBar.fillAmount = Mathf.Lerp(0, max, t);
            yield return new WaitForSeconds(0f);
            if (progressBar.fillAmount == 1f)
            {
                loadSceneCanvas.SetActive(false);
            }
        }
    }

    public IEnumerator LoadingProgressBarReal()
    {
        progressBar.fillAmount = 0;
        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.fillAmount = progress;
            yield return new WaitForSeconds(0f);
            if (progressBar.fillAmount == 1f)
            {
                loadSceneCanvas.SetActive(false);
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        loadSceneCanvas.SetActive(true);

        LoadAsynchronously(sceneIndex);

        StartCoroutine(LoadingProgressBar());
    }

    void LoadAsynchronously(int sceneIndex)
    {
        operation = SceneManager.LoadSceneAsync(sceneIndex);
    }

}
