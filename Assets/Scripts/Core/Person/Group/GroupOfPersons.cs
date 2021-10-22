using System.Collections.Generic;
using Core.Person.Group.Events;
using UnityEngine;

namespace Core.Person.Group
{
    /// <summary>
    /// Класс, описывающий поведение группы персонажей
    /// </summary>
    public class GroupOfPersons : MonoBehaviour
    {
        [SerializeField] protected Material groupMaterial;
        [SerializeField] protected List<Person> persons = new List<Person>();

        public readonly GroupSizeChangedEvent GroupSizeChangedEvent = new GroupSizeChangedEvent();
        public int PersonCount => persons.Count;
        public List<Person> Persons => new List<Person>(persons);

        public Bounds GroupBounds
        {
            get
            {
                if (PersonCount <= 0)
                {
                    return new Bounds(transform.position, Vector3.zero);
                }

                var bounds = new Bounds(persons[0].transform.position, Vector3.zero);
                persons.ForEach(person =>
                {
                    bounds.Encapsulate(person.EntityBounds.min);
                    bounds.Encapsulate(person.EntityBounds.max);
                });
                return bounds;
            }
        }

        public Material GroupMaterial => groupMaterial;
        
        /// <summary>
        /// Присоединяет к группе указанного персонажа
        /// </summary>
        /// <param name="person">присоединяемый персонаж</param>
        public void AddPerson(Person person)
        {
            if (!persons.Contains(person))
            {
                persons.Add(person);
                GroupSizeChanged();
            }
        }
        /// <summary>
        /// Исключает из группы указанного персонажа
        /// </summary>
        /// <param name="person">исключаемый персонаж</param>
        public void RemovePerson(Person person)
        {
            if (persons.Contains(person))
            {
                persons.Remove(person);
                GroupSizeChanged();
            }
        }


        private void GroupSizeChanged()
        {
            GroupSizeChangedEvent.Invoke(new GroupSizeChangedArgs());
        }
    }
}