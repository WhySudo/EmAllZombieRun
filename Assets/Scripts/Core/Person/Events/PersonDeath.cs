using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Person.Events
{
    /// <summary>
    /// Событие смерти персонажа
    /// </summary>
    public class PersonDeathEvent : UnityEvent<PersonDeathArgs>
    {
    }

    [Serializable]
    public class PersonDeathArgs
    {
    }
}