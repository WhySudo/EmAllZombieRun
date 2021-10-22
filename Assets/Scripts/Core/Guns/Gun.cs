using System.Collections;
using Core.Guns.Events;
using UnityEngine;

namespace Core.Guns
{
    /// <summary>
    /// Класс, описывающий поведение оружия
    /// </summary>
    public class Gun : MonoBehaviour
    {
        public readonly GunShotEvent GunShotEvent = new GunShotEvent();
        
        [SerializeField] private GunConfiguration gunConfiguration;
        [Header("Shoot particle")] 
        [SerializeField] private ParticleSystem shootParticle;
        [SerializeField] private Transform shootParticlePosition;
        
        private bool _reloading;
        public float ShootingDistance => gunConfiguration.shootDistance;
        
        /// <summary>
        /// Совершает выстрел из данного оружия
        /// </summary>
        /// <param name="hit">произошел ли выстрел</param>
        /// <param name="damage">количество урона, которое смогло выдать данное оружие</param>
        /// <returns></returns>
        public bool Shoot(out bool hit, out float damage)
        {
            if (_reloading)
            {
                damage = 0;
                hit = false;
                GunShotEvent.Invoke(new GunShotArgs(false, false, 0));
                return false;
            }

            hit = Random.Range(0f, 1f) <= gunConfiguration.accuracy;
            damage = hit ? gunConfiguration.damage : 0;
            StartCoroutine(ReloadGun());
            Instantiate(shootParticle, shootParticlePosition);
            GunShotEvent.Invoke(new GunShotArgs(true, hit, damage));
            return true;
        }
        /// <summary>
        /// корутин перезарядки оружия
        /// </summary>
        /// <returns></returns>
        private IEnumerator ReloadGun()
        {
            _reloading = true;
            yield return new WaitForSeconds(gunConfiguration.reloadTime);
            _reloading = false;
        }
    }
}