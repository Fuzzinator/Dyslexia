using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingBar : MonoBehaviour {

    public GameObject loadObj;
    public Slider loadBar;
    public GameObject startButton;

    private AsyncOperation _async;

    public void LoadScene()
    {
        StartCoroutine(LoadCo());
        
    }

    public void StartButton()
    {
        if (_async.progress >= .9f)
        {
            
            _async.allowSceneActivation = true;
        }
    }

    IEnumerator LoadCo()
    {
        loadObj.SetActive(true);
        _async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        _async.allowSceneActivation = false;
        while (_async.isDone == false)
        {
            yield return new WaitForSeconds(.1f);
            loadBar.value = _async.progress;
            if (_async.progress >= .9f)
            {
                loadBar.value = 1f;
                startButton.SetActive(true);
            }
        }
        yield return null;
    }
}
