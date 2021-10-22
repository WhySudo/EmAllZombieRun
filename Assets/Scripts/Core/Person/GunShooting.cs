using System;
using System.Collections;
using Core.Guns;
using Core.Person.Playable;
using UnityEngine;

namespace Core.Person
{
    /// <summary>
    /// Класс, описывающий поведение сущности, способной стрелять из оружия
    /// </summary>
    public class GunShooting : MonoBehaviour
    {
        [SerializeField] private PlayablePerson person;
        [SerializeField] private Transform gunSlot;
        private Gun _spawnedGun;
        public Gun Gun => _spawnedGun;
        /// <summary>
        /// Осуществляет выстрел из оружия по указанному персонажу
        /// </summary>
        /// <param name="person">цель стрельбы</param>
        public void ShotPerson(Person person)
        {
            var shot = _spawnedGun.Shoot(out var hit, out var damage);
            //TODO:
            if (hit)
            {
                person.Damage(damage);
            }
        }

        private void Awake()
        {
            _spawnedGun = Instantiate(person.PlayablePersonConfiguration.personGun, gunSlot);
        }
    }
}