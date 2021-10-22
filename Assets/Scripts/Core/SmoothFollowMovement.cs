using System;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Скрипт плавного следования за объектом
    /// </summary>
    public class SmoothFollowMovement : MonoBehaviour
    {
        [SerializeField] private float smoothTime;
        [SerializeField] private Transform followTransform;
        [SerializeField] private bool calculateOffsetInAwake;
        [SerializeField] private Vector3 offset;
        [Header("Gizmos"), SerializeField] private float gizmoSphereRadius;
        private Vector3 _currentSpeed;
        private Vector3 _initialOffset;
        public Vector3 TargetPosition => followTransform.position + offset;
        public Transform FollowTransform
        {
            get => followTransform;
            set => followTransform = value;
        }

        public Vector3 Offset
        {
            get => offset;
            set => offset = value;
        }
        /// <summary>
        /// Восстаналивает относительные координаты следования в изначальные значения
        /// </summary>
        public void RestoreOffset()
        {
            offset = _initialOffset;
            transform.position = TargetPosition;
        }
        private void OnDrawGizmos()
        {
            if (followTransform is null) return;
            Gizmos.color = Color.blue;
            var followPosition = followTransform.position;
            var offsetPos = followPosition + offset;
            Gizmos.DrawRay(followPosition, offset);
            Gizmos.DrawSphere(offsetPos, gizmoSphereRadius);
            
        }

        private void Awake()
        {
            _initialOffset = offset;
            if (calculateOffsetInAwake)
            {
                offset = transform.position - followTransform.position;
            }
        }

        private void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, TargetPosition,
                ref _currentSpeed, smoothTime);
        }
    }
}