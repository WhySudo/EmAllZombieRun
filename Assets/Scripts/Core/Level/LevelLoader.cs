using System;
using System.Linq;
using Core.Level.Events;
using Core.Other;
using Core.WinLose;
using PlayerPreferences;
using UnityEngine;

namespace Core.Level
{
    /// <summary>
    /// Класс, загружающий и выгружающий на сцене уровни
    /// </summary>
    public class LevelLoader : MonoBehaviour
    {
        public readonly LevelLoadingStartedEvent LevelLoadingStartedEvent = new LevelLoadingStartedEvent();
        public readonly LevelLoadingEndedEvent LevelLoadingEndedEvent = new LevelLoadingEndedEvent();

        
        [SerializeField] private LevelsConfiguration levelsConfiguration;
        [SerializeField] private Transform levelContainer;
        [SerializeField] private SmoothFollowMovement cameraMovement;
        [SerializeField] private WinLoseChannel winLoseChannel;
        [SerializeField] private PlayerPrefsManager playerPrefsManager;
        [SerializeField] private LookAtFollowed cameraRotation;
        private Level _currentLevel;
        public Level LoadedLevel => _currentLevel;

        /// <summary>
        /// Перезгражует текущий уровень
        /// </summary>
        public void ReloadLevel()
        {
            LoadCurrentLevel();
        }

        /// <summary>
        /// Загружает Следующий уровень
        /// </summary>
        public void LoadNextLevel()
        {
            playerPrefsManager.LevelId = ValidateLevel(playerPrefsManager.LevelId + 1);
            LoadCurrentLevel();
        }
        /// <summary>
        /// Загружает текущий уровень
        /// </summary>
        public void LoadCurrentLevel()
        {
            var level = playerPrefsManager.LevelId;
            LevelLoadingStartedEvent.Invoke(new LevelLoadingStartedArgs(level));
            cameraRotation.RestoreRotation();
            cameraRotation.enabled = false;
            Cleanup();
            var levelPrefab = levelsConfiguration.levelsData.FirstOrDefault(data => data.levelId == level);
            if (levelPrefab is null) return;
            _currentLevel = Instantiate(levelPrefab.levelPrefab, levelContainer);
            _currentLevel.ConfigureLevel();
            cameraMovement.FollowTransform = _currentLevel.CameraPointTransform;
            cameraMovement.RestoreOffset();
            LevelLoadingEndedEvent.Invoke(new LevelLoadingEndedArgs(level));
        }
        /// <summary>
        /// Выгружает загруженный уровень
        /// </summary>
        public void CloseLevel()
        {
            Cleanup();
        }
        /// <summary>
        /// Валидирует значение уровня согласно конфигурации уровней
        /// </summary>
        /// <param name="newLevelId">предполагаемый уровень</param>
        /// <returns>корректный уровень в системе уровней</returns>
        public int ValidateLevel(int newLevelId)
        {
            return Mathf.Max(0, newLevelId) % levelsConfiguration.levelsData.Length;
        }
        /// <summary>
        /// Очистка от уровня
        /// </summary>
        private void Cleanup()
        {
            if (!(_currentLevel is null))
            {
                Destroy(_currentLevel.gameObject);
                _currentLevel = null;
            }
            winLoseChannel.EnableReceiving();
        }
        private void Start()
        {
            playerPrefsManager.LevelId = ValidateLevel(playerPrefsManager.LevelId);
            LoadCurrentLevel();
        }
  
    }
}
