using System;
using UnityEngine;

namespace Core.Person.Group
{
    /// <summary>
    /// Сущность, которая следует за центром группы персонажей
    /// </summary>
    public class FollowGroupTransform : MonoBehaviour
    {
        [SerializeField] private GroupOfPersons groupOfPersons;

        public GroupOfPersons GroupOfPersons
        {
            get => groupOfPersons;
            set => groupOfPersons = value;
        }
        private void Update()
        {
            transform.position = groupOfPersons.GroupBounds.center;
        }
    }
}