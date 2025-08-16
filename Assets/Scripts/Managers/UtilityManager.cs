using System;

[Serializable]
public class UtilityManager
{
    public DamageCalculator damageCalculator { get; private set; }
    
    public void Init()
    {
        damageCalculator = new DamageCalculator();
    }
}
