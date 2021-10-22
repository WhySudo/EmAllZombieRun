using System;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Система паузы, останавливающее таймлайн при выходе в паузу
    /// </summary>
    public class PauseSystem : MonoBehaviour
    {
        private float _normalTimeScale;

        private void Awake()
        {
            _normalTimeScale = Time.timeScale;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = _normalTimeScale;
        }
    }
}