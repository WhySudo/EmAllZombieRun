using UI;
using UnityEngine;

namespace Core.Level
{
    /// <summary>
    /// Класс, отображающий прогресс текущего уровня на прогресс баре
    /// </summary>
    public class LevelProgressView : MonoBehaviour
    {
        [SerializeField] private ProgressBar levelProgressBar;
        [SerializeField] private LevelLoader levelLoader;

        private void Update()
        {
            var levelProgress = levelLoader.LoadedLevel?.LevelProgress ?? 0;
            levelProgressBar.SetProgress(levelProgress);
        }
    }
}