

using Core.Guns;
using UnityEngine;

namespace Core.Person.Playable
{
    
    /// <summary>
    /// Конфигурация персонажа игрока
    /// </summary>
    [CreateAssetMenu(fileName = "playbleConfiguration", menuName = "Configuration/Person/Playable person", order = 0)]
    public class PlayablePersonConfiguration : PersonConfiguration
    {
        
        [Header("Playable person settings")]
        public Gun personGun;
        
    }
}