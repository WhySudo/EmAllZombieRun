using System;
using System.Collections.Generic;
using System.Linq;
using Core.Person.Events;
using UnityEngine;

namespace Core.Person.Targeting
{
    /// <summary>
    /// Класс, описывающий поведение сущностей, которые ищут свою цель в каком то радиусе
    /// </summary>
    /// <typeparam name="TTargetType"></typeparam>
    [RequireComponent(typeof(SphereCollider))]
    public abstract class RadiusTargetSearching<TTargetType> : MonoBehaviour where TTargetType : Component
    {
        [SerializeField] protected Person person;
        [SerializeField] private List<TTargetType> _targetList = new List<TTargetType>();


        protected SphereCollider sphereCollider;

        protected TTargetType ClosestTarget
        {
            get
            {
                CheckTargets();
                if (_targetList.Count == 0) return null;
                return _targetList.OrderBy(playablePerson =>
                    (playablePerson.transform.position - transform.position).magnitude).First();
            }
        }
        
        protected abstract float SearchingRadius { get; }
        /// <summary>
        /// Проверяет, является ли указанная сущность подходящего типа целью
        /// </summary>
        /// <param name="target">проверяемая сущность</param>
        /// <returns></returns>
        protected abstract bool CanBeTarget(TTargetType target);
        protected abstract void OnPersonDeath();
        /// <summary>
        /// Добавляет указанную цель в список доступных целей
        /// </summary>
        /// <param name="person">добавляемая цель</param>
        protected void AddTarget(TTargetType person)
        {
            if (!_targetList.Contains(person))
            {
                _targetList.Add(person);
            }
        }
        /// <summary>
        /// Исключает указанную цель из списка доступных
        /// </summary>
        /// <param name="person">исключаемая цель</param>
        protected void RemoveTarget(TTargetType person)
        {
            if (_targetList.Contains(person))
            {
                _targetList.Remove(person);
            }
        }

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.radius = SearchingRadius;
        }

        private void OnEnable()
        {
            person.PersonDeathEvent.AddListener(OnPersonDeath);
        }

        private void OnPersonDeath(PersonDeathArgs args)
        {
            OnPersonDeath();
            enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<TTargetType>(out var targetPerson)) return;

            if (!CanBeTarget(targetPerson))
            {
                return;
            }

            AddTarget(targetPerson);
        }
        /// <summary>
        /// Формирование списка доступных целей исходя из их возможности быть целью
        /// </summary>
        private void CheckTargets()
        {
            _targetList = new List<TTargetType>(_targetList.Where(CanBeTarget).ToArray());
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<TTargetType>(out var targetPerson)) return;
            RemoveTarget(targetPerson);
        }

        private void OnDisable()
        {
            person.PersonDeathEvent.RemoveListener(OnPersonDeath);
        }
    }
}