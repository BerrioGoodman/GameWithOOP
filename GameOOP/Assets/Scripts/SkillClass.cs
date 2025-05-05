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
        get => iconSkill;
        set => iconSkill = value;
    }

}
