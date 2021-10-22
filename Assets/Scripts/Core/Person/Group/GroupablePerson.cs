using System;
using Core.Person.Events;
using Core.Person.Group.Events;
using UnityEngine;

namespace Core.Person.Group
{
    /// <summary>
    /// Класс - персонаж, способный вступать в группы
    /// </summary>
    public class GroupablePerson : MonoBehaviour
    {
        [SerializeField] private GroupOfPersons groupOfPersons;

        [SerializeField] private Person person;
        public readonly PersonJoinedGroupEvent PersonJoinedGroupEvent = new PersonJoinedGroupEvent();

        public Person Person => person;
        public GroupOfPersons GroupOfPersons => groupOfPersons;
        /// <summary>
        /// Присоединяет персонажа к указанной группе
        /// </summary>
        /// <param name="joinGroupOfPersons">группа в которую надо присоединить персонажа</param>
        public void JoinGroup(GroupOfPersons joinGroupOfPersons)
        {
            if (person.Dead) return;
            if (!(groupOfPersons is null)) return;
            joinGroupOfPersons.AddPerson(person);
            groupOfPersons = joinGroupOfPersons;
            PersonJoinedGroupEvent.Invoke(new PersonJoinedGroupArgs(joinGroupOfPersons));
        }

        private void OnEnable()
        {
            person.PersonDeathEvent.AddListener(OnPersonDeath);
        }

        private void OnPersonDeath(PersonDeathArgs arg0)
        {
            if (!(groupOfPersons is null))
            {
                groupOfPersons.RemovePerson(person);
            }
        }

        private void OnDisable()
        {
            person.PersonDeathEvent.RemoveListener(OnPersonDeath);
        }
    }
}