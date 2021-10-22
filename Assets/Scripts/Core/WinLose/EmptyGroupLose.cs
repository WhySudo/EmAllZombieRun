using System;
using Core.Person;
using Core.Person.Group;
using Core.Person.Group.Events;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Класс, вызывающий проигрыш уровня, если указанная группа оказалаось пустой
    /// </summary>
    public class EmptyGroupLose : MonoBehaviour
    {
        [SerializeField] private GroupOfPersons checkingGroup;
        [SerializeField] private WinLoseChannel winLoseChannel;
        private void OnEnable()
        {
            checkingGroup.GroupSizeChangedEvent.AddListener(OnGroupSizeChanged);
        }

        private void OnDisable()
        {
            checkingGroup.GroupSizeChangedEvent.RemoveListener(OnGroupSizeChanged);
        }

        private void OnGroupSizeChanged(GroupSizeChangedArgs arg0)
        {
            if (checkingGroup.PersonCount <= 0)
            {
                winLoseChannel.Lose();
            }
        }
    }
}