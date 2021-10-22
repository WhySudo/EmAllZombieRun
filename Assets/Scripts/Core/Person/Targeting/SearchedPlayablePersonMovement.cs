using Core.Person.Playable;
using Core.Person.Zombie;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Person.Targeting
{
    /// <summary>
    /// Поведение зомби, начинающее идти к ближайшему доступному игроку
    /// </summary>
    public class SearchedPlayablePersonMovement : RadiusTargetSearching<PlayablePerson>
    {
        [SerializeField] private ZombiePerson zombiePerson;

        [SerializeField] private NavMeshAgent navMeshAgent;
        //Temp
        private float Speed=>zombiePerson.ZombieConfiguration.movementSpeed;
        private void Update()
        {
            var target = ClosestTarget;
            var continueCondition = zombiePerson.Dead || target is null;
            navMeshAgent.isStopped = continueCondition;
            if (continueCondition) return;
            navMeshAgent.SetDestination(target.transform.position);
            
        }

        protected override float SearchingRadius => zombiePerson.ZombieConfiguration.detectionRadius;
        protected override bool CanBeTarget(PlayablePerson target)
        {
            return !target.Dead && !target.IsDummy;
        }

        protected override void OnPersonDeath()
        {
            navMeshAgent.isStopped = true;
        }
    }
}