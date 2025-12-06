using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "GameScene";

    public void Start()
    {
        SceneManager.LoadSceneAsync(mainSceneName);
    }
}
