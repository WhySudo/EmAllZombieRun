using System;
using Core.Person.Events;
using Core.Person.Movable;
using UnityEngine;

namespace Core.Person.Animation
{
    /// <summary>
    /// Общий контроллер аниматоров для персонажей
    /// </summary>
    public class PersonAnimationController : MonoBehaviour
    {
        private static readonly int Walking = Animator.StringToHash("Walking");
        private static readonly int Die = Animator.StringToHash("Die");
        [SerializeField] private MovablePerson movablePerson;
        [SerializeField] private Animator animator;
        [SerializeField] private Person person;

        private void OnEnable()
        {
            person.PersonDeathEvent.AddListener(OnPersonDeath);
        }

        private void OnPersonDeath(PersonDeathArgs arg0)
        {
            animator.SetTrigger(Die);
            animator.applyRootMotion = true;
        }
        private void Update()
        {
            animator.SetBool(Walking, movablePerson.IsMoved);
        }

        private void OnDisable()
        {
            person.PersonDeathEvent.RemoveListener(OnPersonDeath);
        }

    }
}