using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneMgr : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Image prograssBar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;
        SceneManager.LoadScene("Loading_Scene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(op.progress < 0.9f)
            {
                prograssBar.fillAmount = Mathf.Lerp(prograssBar.fillAmount, op.progress, timer);

                if(prograssBar.fillAmount >= op.progress)
                {
                    timer = 0.0f;
                }
            }
            else
            {
                prograssBar.fillAmount = Mathf.Lerp(prograssBar.fillAmount, 1f, timer);

                if(prograssBar.fillAmount == 10.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
