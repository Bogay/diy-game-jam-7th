using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.Model;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/Heal")]
public class Heal : BuffData
{
    public int healAmountOnAttack;
    public int healAmountOnDamaged;
    public int healAmountOnDefense;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnAttack += this.onAttack;
        actor.OnDefense += this.onDefense;
        actor.OnDamaged += this.onDamaged;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnAttack -= this.onAttack;
        actor.OnDefense -= this.onDefense;
        actor.OnDamaged -= this.onDamaged;
    }

    private void onAttack(object sender, UpdateAttackArgs args)
    {
        args.attacker.Health += this.healAmountOnAttack;
    }

    private void onDefense(object sender, UpdateAttackArgs args)
    {
        args.defender.Health += this.healAmountOnDefense;
    }

    private void onDamaged(object sender, UpdateAttackArgs args)
    {
        if (args.defender.Health > 0 && args.attackData.Value > 0)
        {
            args.defender.Health += this.healAmountOnDamaged;
        }
    }
}
