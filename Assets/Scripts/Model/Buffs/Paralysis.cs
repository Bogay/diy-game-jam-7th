using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

// 麻痺
[CreateAssetMenu(menuName = "SO/Buff/Paralysis")]
public class Paralysis : BuffData
{
    [SerializeField]
    private int effectiveAmount;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnMove += this.onMove;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnMove -= this.onMove;
    }

    private void onMove(object sender, UpdateAttackArgs args)
    {
        if (this.effectiveAmount > 0)
        {
            args.attackData.isEffective = false;
            this.effectiveAmount--;
            args.attacker.Game.MessageLog.Add($"{args.attacker}'s move is blocked.");
        }

        if (this.effectiveAmount <= 0)
        {
            this.owner.RemoveBuff(this);
        }
    }
}
