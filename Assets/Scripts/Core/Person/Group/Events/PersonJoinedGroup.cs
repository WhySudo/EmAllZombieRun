using System;
using UnityEngine.Events;

namespace Core.Person.Group.Events
{
    /// <summary>
    /// Событие присоединения персонажа к группе
    /// </summary>
    public class PersonJoinedGroupEvent : UnityEvent<PersonJoinedGroupArgs>
    {
    }

    [Serializable]
    public class PersonJoinedGroupArgs
    {
        public GroupOfPersons groupOfPersons;

        public PersonJoinedGroupArgs(GroupOfPersons groupOfPersons)
        {
            this.groupOfPersons = groupOfPersons;
        }
    }
}