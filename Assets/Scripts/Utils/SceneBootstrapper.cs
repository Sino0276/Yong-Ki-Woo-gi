using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBootstrapper
{
    public static string StartingSceneName { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        if(StartingSceneName == null) StartingSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(" Starting Scene Name: " + StartingSceneName);

        if(StartingSceneName != "Bootstrap") GenerateManager();
    }

    private static void GenerateManager()
    {
        Managers manager = Resources.Load<Managers>("Prefab/Managers");
        Object.Instantiate(manager).name = "Managers";
    }
}
