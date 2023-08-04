using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/OneShotHeal")]
public class OneShotHeal : BuffData
{
    public int Value;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.Health += this.Value;
        // TODO: log
        actor.RemoveBuff(this);
    }
}
