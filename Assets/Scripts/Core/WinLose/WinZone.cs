using System;
using Core.Person.Playable;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Триггер зона,  попав в которую, игровой персонаж вызовет победу
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class WinZone : MonoBehaviour
    {
        [SerializeField] private WinLoseChannel winLoseChannel;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PlayablePerson>(out var person)) return;
            winLoseChannel.Win();
        }
        
    }
}