using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager Instance;

    [SerializeField] private GameObject loadSceneCanvas;
    [SerializeField] private Slider slider;

    ////private float loading;
    
    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadSceneCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }

    //private void Update()
    //{
    //    slider.value = Mathf.MoveTowards(slider.value, loading, 3 * Time.deltaTime);
    //}

    //public async void LoadScene(string sceneName)
    //{
    //    //loading = 0;
    //    //slider.value = 0;

    //    var scene = SceneManager.LoadSceneAsync(sceneName);
    //    scene.allowSceneActivation = false;

    //    loadSceneCanvas.SetActive(true);

    //    do
    //    {
    //        await Task.Delay(100);
    //        slider.value = scene.progress;
    //    }
    //    while (scene.progress < 0.9f);

    //    scene.allowSceneActivation = true;
    //    loadSceneCanvas.SetActive(false);
    //}
}
