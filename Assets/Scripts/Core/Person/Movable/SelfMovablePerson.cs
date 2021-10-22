using UnityEngine;
using UnityEngine.AI;

namespace Core.Person.Movable
{
    /// <summary>
    /// Класс сущности, которая осуществляет свое перемещение самостоятельно
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class SelfMovablePerson : MovablePerson
    {
        private NavMeshAgent _navMeshAgent;
        public override bool IsMoved => !_navMeshAgent.isStopped;
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}