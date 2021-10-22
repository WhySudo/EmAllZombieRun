using UnityEngine;

namespace Core
{

    /// <summary>
    /// Общеигровые настройки
    /// </summary>
    [CreateAssetMenu(fileName = "commonGameConfiguration", menuName = "Configuration/Common Game Configuration", order = 0)]
    public class CommonGameConfiguration : ScriptableObject
    {
        public float stakingDistance;
    }
}