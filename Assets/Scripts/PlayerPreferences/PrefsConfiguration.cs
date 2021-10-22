using UnityEngine;

namespace PlayerPreferences
{
    /// <summary>
    /// Конфигурация работы с PlayerPrefs
    /// </summary>
    [CreateAssetMenu(fileName = "playerPrefsConfiguration", menuName = "Configuration/Player Prefs", order = 0)]
    public class PrefsConfiguration : ScriptableObject
    {
        public string dataKey;
        public PlayerPrefsData defaultPrefsData;
    }
}