using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    [field: SerializeField] public AtkSO AtkSO { get; private set; }
    [field: SerializeField] public AtkSpeedSO AtkSpeedSO { get; private set; }
    [field: SerializeField] public CritRateSO CritRateSO { get; private set; }
    [field: SerializeField] public CritDmgSO CritDmgSO { get; private set; }
    [field: SerializeField] public FeverSO FeverSO { get; private set; }
    [field: SerializeField] public FeverTimeSO FeverTimeSO { get; private set; }
}

[System.Serializable]
public class AtkSO
{
    [field: SerializeField] public AnimationCurve AtkCurve { get; private set; }
    [field: SerializeField] public AnimationCurve AtkPriceCurve { get; private set; }
}

[System.Serializable]
public class AtkSpeedSO
{
    [field: SerializeField] public AnimationCurve AtkSpeedCurve { get; private set; }
    [field: SerializeField] public AnimationCurve AtkSpeedPriceCurve { get; private set; }
}

[System.Serializable]
public class CritRateSO
{
    [field: SerializeField] public AnimationCurve CritRateCurve { get; private set; }
    [field: SerializeField] public AnimationCurve CritRatePriceCurve { get; private set; }
}

[System.Serializable]
public class CritDmgSO
{
    [field: SerializeField] public AnimationCurve CritDmgCurve { get; private set; }
    [field: SerializeField] public AnimationCurve CritDmgPriceCurve { get; private set; }
}

[System.Serializable]
public class FeverSO
{
    [field: SerializeField] public AnimationCurve FeverCurve { get; private set; }
    [field: SerializeField] public AnimationCurve FeverPriceCurve { get; private set; }
}

[System.Serializable]
public class FeverTimeSO
{
    [field: SerializeField] public AnimationCurve FeverTimeCurve { get; private set; }
    [field: SerializeField] public AnimationCurve FeverTimePriceCurve { get; private set; }
}