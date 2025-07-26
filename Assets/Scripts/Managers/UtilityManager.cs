using System;

[Serializable]
public class UtilityManager
{
    public DamageCalculator damageCalculator { get; private set; } = new DamageCalculator();
}
