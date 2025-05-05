using UnityEngine;

public abstract class StatisticsClass
{
    private float maxValue = 100f;
    private float minValue = 0f;
    private float currentValue;

    protected StatisticsClass(float maxValue, float minValue, float currentValue)
    {
        this.maxValue = maxValue;
        this.minValue = minValue;
        this.currentValue = currentValue;
    }

    public float CurrentValue 
    {
        get { return currentValue; } //Read only current value

        //This condition checks if the value is within the min and max range
        protected set 
        {
            if (value >= minValue && value <= maxValue)
            {
                currentValue = value;
            }
            else 
            {
                Debug.LogError("Value out of bounds!");
            }
        }
    }

    public float MinValue //Read and edit only min value
    {
        get { return minValue; }
        protected set 
        {
            if (value < maxValue)
            {
                minValue = value;
            }
            else
            {
                Debug.LogError("Min value cannot be greater than max value!");
            }
        }
        
    }

    public float MaxValue //Read and edit only max value
    {
        get { return maxValue; }
        protected set
        {
            if (value > minValue)
            {
                maxValue = value;
            }
            else
            {
                Debug.LogError("Max value cannot be less than min value!");
            }
        }

    }
}
