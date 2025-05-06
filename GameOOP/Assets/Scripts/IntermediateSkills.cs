using UnityEngine;

public enum SkillType
{
    Attack,
    Defense,
    Support
}
public abstract class IntermediateSkills : SkillClass
{
    protected SkillType skillType {get; set;}
    protected float cost;
    protected float duration; 

    protected IntermediateSkills(string nameSkill, Sprite iconSkill, float cooldown, SkillType skillType, float cost, float duration) : base(nameSkill, iconSkill, cooldown)
    {
        this.skillType = skillType;
        this.cost = cost;
        this.duration = duration;
    }

    public virtual bool CanUse(float currentValue, float cost)
    {
        if (currentValue >= cost)
        {
            return true; //can use the skill
        }
        else
        {
            Debug.Log("Not enough resources to use the skill!");
            return false; //cannot use the skill
        }
    }
       
}
