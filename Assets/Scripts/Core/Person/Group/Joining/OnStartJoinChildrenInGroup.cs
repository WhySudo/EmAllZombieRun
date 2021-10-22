using System;
using UnityEngine;

namespace Core.Person.Group.Joining
{
    /// <summary>
    /// Класс, присоединяющий при запуске всех дочерних персонажей в указанную группу
    /// </summary>
    public class OnStartJoinChildrenInGroup : MonoBehaviour
    {
        [SerializeField] private GroupOfPersons groupOfPersons;

        private void Start()
        {
            foreach (var person in GetComponentsInChildren<GroupablePerson>())
            {
                person.JoinGroup(groupOfPersons);
            }
        }
    }
}