using System;
using UnityEngine;

namespace Core.Level
{
    [Serializable]
    public class LevelData
    {
        public int levelId;
        public Level levelPrefab;
    }
    /// <summary>
    /// Класс, хранящий в себе данные о системе уровней
    /// </summary>
    [CreateAssetMenu(fileName = "levelsConfiguration", menuName = "Configuration/Levels", order = 0)]
    
    public class LevelsConfiguration : ScriptableObject
    {
        public LevelData[] levelsData;

        private void OnValidate()
        {
            for (int i = 0; i < levelsData.Length; i++)
            {
                levelsData[i].levelId = i;
            }
        }
    }
}