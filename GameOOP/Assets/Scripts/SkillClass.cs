using UnityEngine;

public abstract class SkillClass 
{
    private string nameSkill;
    private Sprite iconSkill;
    private float cooldown;

    protected SkillClass(string nameSkill, Sprite iconSkill, float cooldown)
    {
        this.nameSkill = nameSkill;
        this.iconSkill = iconSkill;
        this.cooldown = cooldown;
    }

    public float Cooldown
    {
        get { return cooldown; } //read-only property for cooldown
        set 
        {
            if (value >= 0)
            {
                cooldown = value;
            }
            else
            {
                Debug.LogError("Cooldown cannot be negative");
            }
        }
    }
    public string NameSkill
    {
        get { return nameSkill; }
        protected set 
        {
            if (!string.IsNullOrEmpty(value))
            {
                nameSkill = value;
            }
            else
            {
                Debug.LogError("Skill name cannot be null or empty");
            }
        }
    }

    public Sprite IconSkill
    {
        get{return iconSkill;}

        protected set
        {
            if(value != null)
            {
                iconSkill = value;
            }
            else
            {
                Debug.LogError("Icon cannot be null");
            }
        }
    }

}
