using System;
using UnityEngine;

namespace Core.Guns
{
    /// <summary>
    /// класс, описывающий конфигурацию оружия
    /// </summary>
    [CreateAssetMenu(fileName = "gunConfiguration", menuName = "Configuration/Gun Configuration", order = 0)]
    public class GunConfiguration : ScriptableObject
    {
        [Header("Gun Settings")]
        public float reloadTime;
        public float accuracy;
        public float damage;
        public float shootDistance;
        private void OnValidate()
        {
            accuracy = Mathf.Clamp01(accuracy);
        }
    }
}