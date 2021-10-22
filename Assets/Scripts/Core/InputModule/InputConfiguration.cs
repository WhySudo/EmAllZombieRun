using UnityEngine;

namespace Core.InputModule
{
    /// <summary>
    /// Класс - конфигурация инпута
    /// </summary>
    [CreateAssetMenu(fileName = "inputConfiguration", menuName = "Configuration/Input", order = 0)]
    public class InputConfiguration : ScriptableObject
    {
        public float forwardSpeed;
        public float sideSpeedMultiplier;
        public float sideSpeedLimit = 5;
    }
}