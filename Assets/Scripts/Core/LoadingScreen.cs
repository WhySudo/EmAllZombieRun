using System;
using Core.Level;
using Core.Level.Events;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Загрузочный экран, включаемый при загрузки уровня
    /// </summary>
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private GameObject loadingScreen;
        private void OnEnable()
        {
            loadingScreen.SetActive(false);
            levelLoader.LevelLoadingStartedEvent.AddListener(OnLeveLoadingStarted);
            levelLoader.LevelLoadingEndedEvent.AddListener(OnLeveLoadingEnded);
        }

        private void OnLeveLoadingEnded(LevelLoadingEndedArgs arg0)
        {
            loadingScreen.SetActive(false);
        }

        private void OnLeveLoadingStarted(LevelLoadingStartedArgs arg0)
        {
            loadingScreen.SetActive(true);
        }
        private void OnDisable()
        {
            loadingScreen.SetActive(false);
            levelLoader.LevelLoadingStartedEvent.RemoveListener(OnLeveLoadingStarted);
            levelLoader.LevelLoadingEndedEvent.RemoveListener(OnLeveLoadingEnded);
        }
    }
}