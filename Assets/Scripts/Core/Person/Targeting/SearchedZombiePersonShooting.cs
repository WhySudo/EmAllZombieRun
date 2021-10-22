using Core.Person.Zombie;
using UnityEngine;

namespace Core.Person.Targeting
{
    /// <summary>
    /// Класс, описывающий поведение игрового персонажа, стреляющего в ближайшего доступного зомби
    /// </summary>
    public class SearchedZombiePersonShooting : RadiusTargetSearching<ZombiePerson>
    {
        [SerializeField] private GunShooting gunShooting;
        public bool Shooting => _shooting;
        protected override float SearchingRadius => gunShooting.Gun.ShootingDistance;

        private bool _shooting;
        protected override bool CanBeTarget(ZombiePerson target)
        {
            return !target.Dead;
        }

        protected override void OnPersonDeath()
        {
            
        }

        private void Update()
        {
            var target = ClosestTarget;
            if (target is null)
            {
                _shooting = false;
                return;
            }
            _shooting = true;
            person.LookAt(target.transform.position);
            gunShooting.ShotPerson(target);
        }
    }
}