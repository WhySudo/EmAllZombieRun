using Core.Person;
using Core.Person.Group;
using UI;
using UnityEngine;

namespace Core.Level
{
    /// <summary>
    /// Класс, отслеживающий текущий "прогресс" прохождения уровня
    /// </summary>
    public class LevelProgressChecker : MonoBehaviour
    {
        [SerializeField] private GroupOfPersons playerGroup;
        [SerializeField] private Collider levelFinishZone;

        private float _maxDistance;
        public float Progress => 1 - GetCurrentDistance() / _maxDistance;
        
        
        /// <summary>
        /// Инициализирует начальную точку
        /// </summary>
        public void InitStartPoint()
        {
            _maxDistance = GetCurrentDistance();
        }
        /// <summary>
        /// Вычисляет текущую дистанцию до финиша
        /// </summary>
        /// <returns>текущая дистанция до финиша</returns>
        private float GetCurrentDistance()
        {
            var startPoint = playerGroup.GroupBounds.ClosestPoint(levelFinishZone.bounds.center);
            var endPoint = levelFinishZone.ClosestPoint(startPoint);
            return (endPoint - startPoint).magnitude;
        }
    }
}