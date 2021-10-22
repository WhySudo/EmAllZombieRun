using Core.WinLose;
using Core.WinLose.Events;
using UnityEngine;

namespace Core.Person.Animation
{
    /// <summary>
    /// Контроллер аниматора для зомби
    /// </summary>
    public class ZombieAnimationController : MonoBehaviour
    {
        private static readonly int Win = Animator.StringToHash("Win");
        [SerializeField] private Animator animator;
        [SerializeField] private WinLoseChannel winLoseChannel;
        private void OnEnable()
        {
            winLoseChannel.GameLoseEvent.AddListener(OnGameLost);
            
        }

        private void OnGameLost(GameLoseArgs arg0)
        {
            
            animator.applyRootMotion = true;
            animator.SetTrigger(Win);
        }

  
        private void OnDisable()
        {
            winLoseChannel.GameLoseEvent.RemoveListener(OnGameLost);
        }
    }
}