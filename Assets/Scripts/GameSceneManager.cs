using System;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Класс, отвечающий за переключение сцен в игре
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private SceneConfiguration sceneConfiguration;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(sceneConfiguration.mainSceneName);
    }

    public void LoadCoreScene()
    {
        SceneManager.LoadScene(sceneConfiguration.coreSceneName);
    }
}