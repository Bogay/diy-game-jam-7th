using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using UniDi;

public enum ModifyAttribute
{
    Health,
    MaxHealth,
    Attack,
}

[System.Serializable]
public class ModifyAttributeItem
{
    public ModifyAttribute attribute;
    public int value;

    public void Apply(Actor actor)
    {
        switch (this.attribute)
        {
            case ModifyAttribute.Health:
                actor.Health += this.value;
                break;
            case ModifyAttribute.MaxHealth:
                actor.MaxHealth += this.value;
                break;
            case ModifyAttribute.Attack:
                actor.Attack += this.value;
                break;
        }
    }
}

// FIXME: use more extensible approach to implement
[CreateAssetMenu(menuName = "SO/Buff/DeathListener")]
public class DeathListener : BuffData
{
    [SerializeField]
    private List<ModifyAttributeItem> modifications;

    [Inject(Id = "source")]
    private Actor source;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnDead += this.onDead;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnDead -= this.onDead;
    }

    private void onDead(object sender, UpdateAttackArgs args)
    {
        if (args.attacker == this.source)
        {
            foreach (var m in modifications)
            {
                m.Apply(this.source);
            }
        }
    }
}
