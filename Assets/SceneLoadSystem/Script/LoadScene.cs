using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [Header("Transition")]
    [SerializeField]
    private TransitionController transitionController;


    /// <summary>
    /// ロード画面経由でScene遷移
    /// </summary>
    public void LoadSceneNext(string sceneName)
    {
        StartCoroutine(
            LoadSceneCoroutine(sceneName)
        );
    }


    /// <summary>
    /// ロード画面を使わず、
    /// 現在のScene上でTransitionしながらScene遷移
    /// </summary>
    public void LoadSceneDirect(string sceneName)
    {
        StartCoroutine(
            LoadSceneDirectCoroutine(sceneName)
        );
    }


    /// <summary>
    /// ロード画面経由のScene遷移
    /// </summary>
    private IEnumerator LoadSceneCoroutine(
        string sceneName)
    {
        // Transition In
        if (transitionController != null)
        {
            yield return StartCoroutine(
                transitionController.PlayIn()
            );
        }


        // ロード画面へ
        SceneLoader.Load(
            sceneName,
            transitionController != null
                ? transitionController.Transition
                : null
        );
    }


    /// <summary>
    /// ロード画面を使わないScene遷移
    /// </summary>
    private IEnumerator LoadSceneDirectCoroutine(
        string sceneName)
    {
        // --------------------------------
        // Transition In
        // --------------------------------

        if (transitionController != null)
        {
            yield return StartCoroutine(
                transitionController.PlayIn()
            );
        }


        // --------------------------------
        // 次のSceneを非同期ロード
        // --------------------------------

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);

        // ロード完了してもすぐSceneを切り替えない
        operation.allowSceneActivation = false;


        // --------------------------------
        // ロード完了待ち
        // --------------------------------

        while (operation.progress < 0.9f)
        {
            yield return null;
        }


        // --------------------------------
        // Scene切り替え
        // --------------------------------

        operation.allowSceneActivation = true;
    }
}