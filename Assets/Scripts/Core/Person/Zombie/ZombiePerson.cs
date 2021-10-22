using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Person.Zombie
{
    /// <summary>
    /// Класс, описывающий поведение персонажа зомби
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]

    public class ZombiePerson : Person
    {
        [SerializeField] private ZombieConfiguration zombieConfiguration;

        public ZombieConfiguration ZombieConfiguration => zombieConfiguration;
        public override PersonConfiguration PersonConfiguration => zombieConfiguration;

    }
}