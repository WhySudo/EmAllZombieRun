using System;
using UnityEngine;

namespace Core.Other
{
    /// <summary>
    /// Класс, поворачивающийся в сторону следуемого <see cref="SmoothFollowMovement"/> объекта
    /// </summary>
    [RequireComponent(typeof(SmoothFollowMovement))]
    public class LookAtFollowed : MonoBehaviour
    {
        private SmoothFollowMovement _followMovement;
        private Quaternion _initialRotation;

        public void RestoreRotation()
        {
            transform.rotation = _initialRotation;
        }
        private void Awake()
        {
            _followMovement = GetComponent<SmoothFollowMovement>();
            _initialRotation = transform.rotation;
        }

        private void Update()
        {
            transform.LookAt(_followMovement.FollowTransform.position);
        }
    }
}