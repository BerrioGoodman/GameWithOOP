using UnityEngine;

public enum ManaState //this enum is used to define the mana state
{
    Time,
    Instant
}

public class ManaSystemClass : StatisticsClass
{
    private float speedRecharge; //this variable is used to define the speed of mana recharge

    
    public ManaSystemClass(float maxValue, float minValue, float currentValue, float speedRecharge) : base(maxValue, minValue, currentValue)
    {
        this.speedRecharge = speedRecharge;
    }

    public void RechargeMana(float amount, ManaState state)
    {
        if (state == ManaState.Time)
        {
            CurrentValue += amount * Time.deltaTime * speedRecharge; //recharge the mana over time
        }
        else if(state == ManaState.Instant)
        {
            CurrentValue += amount; //recharge the mana instantly
        }

        Mathf.Clamp(CurrentValue, MinValue, MaxValue);
    }


}
