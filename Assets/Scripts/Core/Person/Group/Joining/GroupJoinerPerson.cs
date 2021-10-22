using System;
using Core.Person.Group.Events;
using UnityEngine;

namespace Core.Person.Group.Joining
{
    
    /// <summary>
    /// Класс сущности, которая присоединяет в группу ближайших к ней персонажей
    /// </summary>
    [RequireComponent(typeof(SphereCollider))]
    public class GroupJoinerPerson : MonoBehaviour
    {
        [SerializeField]
        private GroupablePerson groupablePerson;

        private SphereCollider _sphereCollider;
        private void Awake()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }
        
        private void Start()
        {
            _sphereCollider.radius = groupablePerson.Person.CommonGameConfiguration.stakingDistance;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var personGroup = groupablePerson.GroupOfPersons;
            if (personGroup is null) return;
            if (!other.TryGetComponent<GroupablePerson>(out var joiningPerson)) return;     
            if (joiningPerson.GroupOfPersons == null)
            {
                joiningPerson.JoinGroup(personGroup);
            }
        }

    }
}