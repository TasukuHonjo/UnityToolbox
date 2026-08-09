using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    /// <summary>
    /// 次に読み込むScene
    /// </summary>
    public static string NextSceneName;


    /// <summary>
    /// 次のSceneで使用するTransition
    /// </summary>
    public static TransitionBehaviour NextTransition;


    /// <summary>
    /// ロード画面経由でScene遷移
    /// </summary>
    public static void Load(
        string sceneName,
        TransitionBehaviour transition)
    {
        NextSceneName = sceneName;
        NextTransition = transition;

        SceneManager.LoadScene("LoadScene");
    }
}