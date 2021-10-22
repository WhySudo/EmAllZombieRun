using System;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Поворачивает сущность при победе
    /// </summary>
    public class OnWinRotate : OnWinLoseAction
    {
        [SerializeField] private Vector3 targetRotation;
        [SerializeField] private float smoothRotatingTime;
        private bool _startedRotating = false;
        private Vector3 _currentSpeed;
        protected override void OnGameLostAction()
        {
        }

        protected override void OnGameWinAction()
        {
            _startedRotating = true;
        }

        private void Update()
        {
            if (!_startedRotating) return;
            var current = transform.rotation.eulerAngles;
            current = Vector3.SmoothDamp(current, targetRotation, ref _currentSpeed, smoothRotatingTime);
            transform.rotation = Quaternion.Euler(current);
        }
    }
}