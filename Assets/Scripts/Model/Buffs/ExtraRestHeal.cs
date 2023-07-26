using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.Model;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Buff/ExtraRestHeal")]
public class ExtraRestHeal : BuffData
{
    public int Value;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnRest += this.onRest;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnRest -= this.onRest;
    }

    private void onRest(object sender, RestArgs args)
    {
        args.Value.buffConst += this.Value;
    }
}
