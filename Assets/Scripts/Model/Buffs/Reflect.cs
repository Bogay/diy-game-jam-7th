using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/Reflect")]
public class Reflect : BuffData
{
    [Inject]
    private CommandSystem commandSystem;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnDefense += this.onDefense;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnDefense -= this.onDefense;
    }

    private void onDefense(object sender, UpdateAttackArgs args)
    {
        args.attackData.isEffective = false;
        this.owner.RemoveBuff(this);

        AttackData newData = new AttackData(args.attackData.Value);
        args.attacker.Game.MessageLog.Add($"Reflect {newData.Value} damage.");
        this.commandSystem.Attack(args.defender, args.attacker, newData);
    }
}
