using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/AddBuffOnAttack")]
public class AddBuffOnAttack : BuffData
{
    [SerializeField]
    private List<BuffData> buffs;

    [Inject]
    BuffData.Factory factory;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnAttack += this.onAttack;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnAttack -= this.onAttack;
    }

    private void onAttack(object sender, UpdateAttackArgs args)
    {
        foreach (var buff in buffs)
        {
            args.defender.AddBuff(this.factory.Create(buff));
        }
    }
}
