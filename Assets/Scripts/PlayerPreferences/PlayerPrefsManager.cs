using System;
using UnityEngine;

namespace PlayerPreferences
{
    /// <summary>
    /// Класс, отвечающий за работу с PlayerPrefs
    /// </summary>
    public class PlayerPrefsManager : MonoBehaviour
    {
        [SerializeField] private PrefsConfiguration prefsConfiguration;

        private PlayerPrefsData _playerPrefsData;

        public int LevelId
        {
            get => _playerPrefsData.currentLevel;
            set => _playerPrefsData.currentLevel = value;
        }

        private void OnEnable()
        {
            LoadData();
        }

        private void OnDisable()
        {
            SaveData();
        }

        private void LoadData()
        {
            var data = PlayerPrefs.GetString(prefsConfiguration.dataKey, JsonUtility.ToJson(prefsConfiguration.defaultPrefsData));
            _playerPrefsData = JsonUtility.FromJson<PlayerPrefsData>(data);
            
        }

        private void SaveData()
        {
            var data = JsonUtility.ToJson(_playerPrefsData);
            PlayerPrefs.SetString(prefsConfiguration.dataKey, data);
            PlayerPrefs.Save();
        }
    }
}