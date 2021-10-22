using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.InputModule
{
    /// <summary>
    /// Класс, считывающий инпут и сообщающий о нем в канал инпута
    /// </summary>
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private InputChannel inputChannel;
        [SerializeField] private InputConfiguration inputConfiguration;
        [SerializeField] private int inputSourceId = 0;
        [SerializeField] private EventSystem eventSystem;
        private bool _inputStarted = false;

        private void Update()
        {
            if (Input.touchCount == 0) return;
            var touch = Input.GetTouch(inputSourceId);
            switch (touch)
            {
                case {phase: TouchPhase.Began}:
                    OnInputBegan(touch);
                    break;
                case {phase: TouchPhase.Moved}:
                case {phase: TouchPhase.Stationary}:
                    OnInputHolding(touch);
                    break;
                case {phase: TouchPhase.Ended}:
                case {phase: TouchPhase.Canceled}:
                    OnInputEnded(touch);
                    break;
            }
        }

        private void OnInputBegan(Touch touch)
        {
            if (eventSystem.IsPointerOverGameObject(touch.fingerId)) return;
            BeginInput();
        }

        private void OnInputHolding(Touch touch)
        {
            if (!_inputStarted) return;

            if (eventSystem.IsPointerOverGameObject(touch.fingerId))
            {
                StopInput();
                return;
            }

            var inputData = ConfigureInputData(touch.deltaPosition) * Time.deltaTime;
            inputChannel.Move(inputData);
        }

        private void OnInputEnded(Touch touch)
        {
            StopInput();
        }

        private void StopInput()
        {
            _inputStarted = false;
            inputChannel.InputEnded();
        }

        private void BeginInput()
        {
            _inputStarted = true;
            inputChannel.InputBegan();
        }

        /// <summary>
        /// Корректирует "сырые" полученные данные из инпута в соответствии с конфигурацией инпута
        /// </summary>
        /// <param name="rawInputData">"сырые" данные инпута</param>
        /// <returns>Откорректированные данные инпута</returns>
        private Vector3 ConfigureInputData(Vector2 rawInputData)
        {
          /*  var rawXValue = Mathf.Clamp(rawInputData.x * inputConfiguration.sideSpeedMultiplier,
                -inputConfiguration.sideSpeedLimit, inputConfiguration.sideSpeedLimit);*/
            var normalizedData = new Vector3(rawInputData.x * inputConfiguration.sideSpeedMultiplier, 0, 0);
            var configuredData = normalizedData + Vector3.forward * inputConfiguration.forwardSpeed;
            return configuredData;
        }
    }
}