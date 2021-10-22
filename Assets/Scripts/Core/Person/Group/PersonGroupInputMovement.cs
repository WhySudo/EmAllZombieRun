using System;
using System.Collections.Generic;
using Core.InputModule;
using Core.InputModule.Events;
using Core.Person.Group.Events;
using Core.Person.Movable;
using UnityEngine;

namespace Core.Person.Group
{
    /// <summary>
    /// Класс описывающий поведение движения группы персонажей
    /// </summary>
    [RequireComponent(typeof(GroupOfPersons))]
    public class PersonGroupInputMovement : MonoBehaviour
    {
        [SerializeField] private Level.Level level;
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private GroupOfPersons groupOfPersons;
        private List<ManagedMovablePerson> _managedMovablePersons = new List<ManagedMovablePerson>();

        private void OnEnable()
        {
            UpdateList();
            inputChannel.InputMoveRequestEvent.AddListener(OnInputMoveRequest);
            inputChannel.InputBeganEvent.AddListener(OnInputBegan);
            inputChannel.InputEndedEvent.AddListener(OnInputEnded);
            groupOfPersons.GroupSizeChangedEvent.AddListener(OnGroupChanged);
        }

        private void OnGroupChanged(GroupSizeChangedArgs arg0)
        {
            UpdateList();
        }

        /// <summary>
        /// Обновляет список персонажей, которых можно перемещать
        /// </summary>
        private void UpdateList()
        {
            _managedMovablePersons.Clear();
            foreach (var person in groupOfPersons.Persons)
            {
                if (!person.TryGetComponent<ManagedMovablePerson>(out var movable)) return;
                _managedMovablePersons.Add(movable);
            }
        }

        private void OnInputEnded(InputEndedArgs arg0)
        {
            _managedMovablePersons.ForEach(movable => movable.EndMove());
        }

        private void OnInputBegan(InputBeganArgs arg0)
        {
            _managedMovablePersons.ForEach(movable => movable.BeginMove());
        }

        private void OnInputMoveRequest(InputMoveRequestArgs args)
        {
            var realMovement = CorrectedMove(groupOfPersons.GroupBounds, level.Bounds, args.deltaMove);
            _managedMovablePersons.ForEach(movable => movable.Move(realMovement));
        }

        private void OnDisable()
        {
            inputChannel.InputMoveRequestEvent.RemoveListener(OnInputMoveRequest);
            inputChannel.InputBeganEvent.RemoveListener(OnInputBegan);
            inputChannel.InputEndedEvent.RemoveListener(OnInputEnded);
            groupOfPersons.GroupSizeChangedEvent.RemoveListener(OnGroupChanged);
        }
        /// <summary>
        /// Корректирует предполагаемое перемещение, если то выходит за границы уровня
        /// </summary>
        /// <param name="movingGroupBounds">границы перемещаемой группы</param>
        /// <param name="levelBounds">Границы уровня</param>
        /// <param name="expectedMove">Ожидаемое перемещение</param>
        /// <returns></returns>
        private Vector3 CorrectedMove(Bounds movingGroupBounds, Bounds levelBounds, Vector3 expectedMove)
        {
            var minMove = movingGroupBounds.min + expectedMove; //минимально возможная итоговая координата перемещения
            var maxMove = movingGroupBounds.max + expectedMove; //максимально возможная итоговая координата перемещеия
            if (!levelBounds.Contains(minMove))
            {
                return levelBounds.ClosestPoint(minMove) - movingGroupBounds.min;//корректируем движение по минимальной границе
            }

            if (!levelBounds.Contains(maxMove))
            {
                return levelBounds.ClosestPoint(maxMove) - movingGroupBounds.max;//корректируем движение по максимальной границе
            }

            return expectedMove;//возвращаем предполагаемое перемещение
        }
    }
}