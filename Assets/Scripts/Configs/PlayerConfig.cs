using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 1000f)] public float SwipeThreshold { get; private set; }
        [field: SerializeField, Range(0, 20f)] public float LineDistance { get; private set; }
        [field: SerializeField, Range(0, 5f)] public float DurationMoving { get; private set; }
    }
}
