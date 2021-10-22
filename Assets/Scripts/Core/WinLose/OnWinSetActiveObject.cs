using System;
using System.Collections;
using Core.WinLose.Events;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Класс, активирующий указанный объект на сцене по событию победы
    /// </summary>
    public class OnWinSetActiveObject : OnWinLoseAction
    {
        [Header("WinObject")]
        [SerializeField] private GameObject winDisplayObject;
        [SerializeField] private float winActionDelay;
        [SerializeField] private bool winActiveStatus = true;

        [Header("LoseObject")]
        [SerializeField] private GameObject loseDisplayObject;
        [SerializeField] private float loseActionDelay;
        [SerializeField] private bool loseActiveStatus = true;
        private IEnumerator EnableObject(GameObject displayObject, float delay, bool status)
        {
            if (displayObject is null) yield break;
            yield return new WaitForSeconds(delay);
            displayObject.SetActive(status);
        }

        protected override void OnGameLostAction()
        {
            StartCoroutine(EnableObject(loseDisplayObject, loseActionDelay, loseActiveStatus));
        }

        protected override void OnGameWinAction()
        {
            StartCoroutine(EnableObject(winDisplayObject, winActionDelay, winActiveStatus));
        }
        

    }
}