using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/Otokonoko")]
public class Otokonoko : BuffData
{
    [SerializeField]
    private int value;

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
        if (args.attacker.actorData.m_sexualOrientation == CharacterSO.Gender.female)
        {
            args.attackData.buffConst -= this.value;
        }
    }
}
