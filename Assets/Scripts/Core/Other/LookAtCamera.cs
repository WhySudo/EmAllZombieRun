using System;
using UnityEngine;

namespace Core.Other
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _storedCamera;

        private void Start()
        {
            _storedCamera = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(_storedCamera.transform);
        }
    }
}