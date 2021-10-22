using System;
using Core.Person.Playable;
using Core.Person.Targeting;
using Core.WinLose;
using Core.WinLose.Events;
using UnityEngine;

namespace Core.Person.Animation
{
    /// <summary>
    /// Контроллер аниматора для игрового персонажа
    /// </summary>
    public class PlayableAnimationController : MonoBehaviour
    {
        private static readonly int Shooting = Animator.StringToHash("Shooting");
        private static readonly int Win = Animator.StringToHash("Win");
        [SerializeField] private SearchedZombiePersonShooting zombieShooting;
        [SerializeField] private Animator animator;

        [SerializeField] private WinLoseChannel winLoseChannel;


        private void OnEnable()
        {
            winLoseChannel.GameWinEvent.AddListener(OnGameWon);
            
        }

        private void Update()
        {
            animator.SetBool(Shooting, zombieShooting.Shooting);
        }
        private void OnGameWon(GameWinArgs arg0)
        {
            animator.applyRootMotion = true;
            animator.SetTrigger(Win);
        }
        private void OnDisable()
        {
            winLoseChannel.GameWinEvent.RemoveListener(OnGameWon);
        }
    }
}