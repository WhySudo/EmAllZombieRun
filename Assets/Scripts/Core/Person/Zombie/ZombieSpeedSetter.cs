using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Person.Zombie
{
    /// <summary>
    /// Компонент зомби, который задает ему скорость
    /// </summary>
    public class ZombieSpeedSetter : MonoBehaviour
    {
        [SerializeField] private ZombiePerson zombie;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private void Awake()
        {
            navMeshAgent.speed = zombie.ZombieConfiguration.movementSpeed;
        }
    }
}