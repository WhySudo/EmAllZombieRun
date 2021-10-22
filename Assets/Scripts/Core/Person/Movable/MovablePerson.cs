using UnityEngine;

namespace Core.Person.Movable
{
    /// <summary>
    /// Класс, описывающий поведение сущности, способной к перемещению
    /// </summary>
    public abstract class MovablePerson: MonoBehaviour
    {
        public abstract bool IsMoved { get; }

    }
}