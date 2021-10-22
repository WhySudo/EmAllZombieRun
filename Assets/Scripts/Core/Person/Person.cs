using System;
using Core.Person.Events;
using UnityEngine;

namespace Core.Person
{
    /// <summary>
    /// Класс, описывающий общую сущность персонажа
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public abstract class Person : MonoBehaviour
    {
        [Header("Common Person Settings")]
        [SerializeField] private Collider personCollider;
        [SerializeField] private float timeToDestroyAfterDeath = 0f;
        [SerializeField] private CommonGameConfiguration commonGameConfiguration;
        [SerializeField] private GameObject lifeTimeBehaviour;
        
        private float _health;
        //Events
        public readonly PersonDeathEvent PersonDeathEvent = new PersonDeathEvent();
        
        //public props
        public CommonGameConfiguration CommonGameConfiguration => commonGameConfiguration;
        public abstract PersonConfiguration PersonConfiguration { get; }
        public float NormalizedHealth => _health / PersonConfiguration.maxHp;
        public bool Dead => _health <= 0;
        public Bounds EntityBounds => personCollider.bounds;
        
        /// <summary>
        /// Поворачивает сущность к указанной точке
        /// </summary>
        /// <param name="direction">точка, к которой нужно повернуть сущность</param>
        public void LookAt(Vector3 direction)
        {
            transform.LookAt(direction);
        }
        /// <summary>
        /// Получает урон
        /// </summary>
        /// <param name="damage">наносимый урон</param>
        public void Damage(float damage)
        {
            if (Dead) return;
            _health = Mathf.Max(_health - damage, 0);
            CheckDeath();
        }
        /// <summary>
        /// Смерть, вызванная убийством
        /// </summary>
        public void Kill()
        {
            Damage(PersonConfiguration.maxHp);
        }
        /// <summary>
        /// Проверяет, нужно ли вызвать событие смерти
        /// </summary>
        private void CheckDeath()
        {
            if (!Dead) return;
            PersonDeathEvent.Invoke(new PersonDeathArgs());
            lifeTimeBehaviour.SetActive(false);//отключает основное поведение
            Destroy(gameObject, timeToDestroyAfterDeath);
        }
        private void Awake()
        {
            _health = PersonConfiguration.maxHp;
        }

    }
}