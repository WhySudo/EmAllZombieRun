using Core.Person.Playable;
using UnityEngine;

namespace Core.Person.Other
{
    /// <summary>
    /// Класс уничтожающий игрового персонажа, если тот сталкивается с сущностью
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PlayablePersonDeathTouch : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PlayablePerson>(out var person)) return;
            
            person.Kill();
        }
    }
}