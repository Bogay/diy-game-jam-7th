using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/Yandere")]
public class Yandere : BuffData
{
    [SerializeField]
    private int lose;
    [SerializeField]
    private int gain;

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
        args.attackData.buffConst += ((this.owner.MaxHealth - this.owner.Health) / this.lose) * this.gain;
    }
}
