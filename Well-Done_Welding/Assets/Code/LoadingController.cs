using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Slider progressBar;
    [SerializeField]
    TMP_Text loadingText;
    [SerializeField]
    TMP_Text completeText;
    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Load");
    }

    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);//LoadScene �����Ȳ -> AsyncOperation Ÿ������ ��ȯ
        op.allowSceneActivation = false;//Scene�� 90%������ �ε��ϰ� ��� -> �ε��� ������ ���̵� X

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.value = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.value = Mathf.Lerp(0.9f,1f,timer);
                if(progressBar.value >= 1f)
                {
                    loadingText.gameObject.SetActive(false);
                    completeText.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }
            }
        }
    }

}
