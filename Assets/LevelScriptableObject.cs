using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "Game Data/Level Scriptable Object")]
    public class LevelScriptableObject : ScriptableObject
    {
        public int maxCoin = 10;
    }
}