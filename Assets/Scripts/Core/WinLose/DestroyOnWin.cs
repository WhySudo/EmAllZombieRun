using System.Collections.Generic;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Уничтожает указанные объекты в случае победы
    /// </summary>
    public class DestroyOnWin : OnWinLoseAction
    {
        [SerializeField] private List<GameObject> destroyList;
        protected override void OnGameLostAction()
        {
        }

        protected override void OnGameWinAction()
        {
            destroyList.ForEach(Destroy);
        }
    }
}