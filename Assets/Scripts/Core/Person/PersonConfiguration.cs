using UnityEngine;

namespace Core.Person
{
    /// <summary>
    /// Общие настройки персонажа
    /// </summary>
    [CreateAssetMenu(fileName = "personConfiguration", menuName = "Configuration/Person/Common person", order = 0)]
    public class PersonConfiguration : ScriptableObject
    {

        [Header("Common settings")]
        public float maxHp;
        
    }
}