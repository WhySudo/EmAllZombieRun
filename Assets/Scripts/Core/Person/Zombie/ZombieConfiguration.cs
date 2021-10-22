using UnityEngine;

namespace Core.Person.Zombie
{
    /// <summary>
    /// Параметры персонажа зомби
    /// </summary>

    [CreateAssetMenu(fileName = "zombieConfiguration", menuName = "Configuration/Person/Zombie", order = 0)]
    public class ZombieConfiguration : PersonConfiguration
    {
        
        [Header("Zombie settings")]
        public float detectionRadius;
        public float movementSpeed;
    }
}