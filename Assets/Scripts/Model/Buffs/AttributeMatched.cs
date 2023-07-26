using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.Model;
using UnityEngine;

// 己方性癖對上對方性徵	造成傷害減一
// 己方性向對上對方性別	造成傷害減一
[CreateAssetMenu(menuName = "SO/Buff/AttributeMatched")]
public class AttributeMatched : BuffData
{
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
        if ( /* 己方性癖對上對方性徵 */ false)
            args.attackData.buffConst--;
        if ( /* 己方性向對上對方性別 */ false)
            args.attackData.buffConst--;
    }
}
