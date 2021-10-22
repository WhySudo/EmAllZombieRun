using UnityEngine.Events;

namespace Core.Guns.Events
{
    /// <summary>
    /// Класс - событие выстрела из пушки
    /// </summary>
    public class GunShotEvent : UnityEvent<GunShotArgs>
    {
    }

    public class GunShotArgs
    {
        public bool shot;
        public bool hit;
        public float damage;

        public GunShotArgs(bool shot, bool hit, float damage)
        {
            this.shot = shot;
            this.hit = hit;
            this.damage = damage;
        }
    }
}