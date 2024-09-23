using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "GameBoardConfig", menuName = "Configs/GameBoard")]
    public class GameBoardConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 100f)] public float MinSpeed { get; private set; } = 1.0f;
        [field: SerializeField, Range(0, 100f)] public float MaxSpeed { get; private set; } = 25.0f;
        [field: SerializeField, Range(0, 100f)] public float AccelerationLerpRate { get; private set; } = 5.0f;
        [field: SerializeField, Range(0, 100f)] public float DecelerationLerpRate { get; private set; } = 2.5f;
    }
}
