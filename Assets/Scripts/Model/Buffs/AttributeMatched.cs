using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.Model;
using UnityEngine;

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
        // 己方性癖對上對方性徵	造成傷害減一
        if (this.isFetishMatched(args.attacker, args.defender))
            args.attackData.buffConst--;
        // 己方性向對上對方性別	造成傷害減一
        if (this.isOrientationMatched(args.attacker, args.defender))
            args.attackData.buffConst--;
    }

    private bool isFetishMatched(Actor attacker, Actor defender)
    {
        return attacker.actorData.m_fetish == defender.actorData.m_sexualCharacteristics_01 ||
            attacker.actorData.m_fetish == defender.actorData.m_sexualCharacteristics_02 ||
            attacker.actorData.m_fetish == defender.actorData.m_sexualCharacteristics_03;
    }

    private bool isOrientationMatched(Actor attacker, Actor defender)
    {
        return attacker.actorData.m_sexualOrientation == defender.actorData.m_gender;
    }
}
