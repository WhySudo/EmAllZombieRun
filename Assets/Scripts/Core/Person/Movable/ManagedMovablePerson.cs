using Core.InputModule;
using Core.InputModule.Events;
using UnityEngine;

namespace Core.Person.Movable
{
    /// <summary>
    /// Класс сущности, перемещение которой является управляемым
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class ManagedMovablePerson : MovablePerson
    {
        [SerializeField] protected CharacterController characterController;

        private bool _inputActive = false;
        public override bool IsMoved => _inputActive;


        public void BeginMove()
        {
            _inputActive = true;
        }

        public void Move(Vector3 deltaMove)
        {
            _inputActive = true;
            characterController.Move(deltaMove);
            transform.forward = (Vector3.forward+deltaMove.normalized).normalized;
        }

        public void EndMove()
        {
            _inputActive = false;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }
    }
}