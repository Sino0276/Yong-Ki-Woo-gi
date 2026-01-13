using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    [field: SerializeField] public AnimationCurve DamageCurve { get; private set; }
    [field: SerializeField] public AnimationCurve AttackSpeedCurve { get; private set; }
    [field: SerializeField] public AnimationCurve CriticalRateCurve { get; private set; }
    [field: SerializeField] public AnimationCurve CriticalDamageCurve { get; private set; }
    [field: SerializeField] public AnimationCurve FeverCurve { get; private set; }
    [field: SerializeField] public AnimationCurve FeverTimeCurve { get; private set; }
}
