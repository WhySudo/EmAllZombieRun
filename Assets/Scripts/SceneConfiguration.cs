using UnityEngine;


/// <summary>
/// конфигурация названия сцен
/// </summary>
[CreateAssetMenu(fileName = "sceneConfiguration", menuName = "Configuration/Scenes", order = 0)]
public class SceneConfiguration : ScriptableObject
{
    public string mainSceneName;
    public string coreSceneName;
}