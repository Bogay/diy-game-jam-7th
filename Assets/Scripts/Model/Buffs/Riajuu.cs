using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;
using System.Linq;

[CreateAssetMenu(menuName = "SO/Buff/Riajuu")]
public class Riajuu : BuffData
{
    [SerializeField]
    private int actorNum;
    [SerializeField]
    private int gain;

    private readonly SkillRange range = new SkillRange
    {
        Direction = SkillDirection.Around,
        Distance = 1,
        MaxTargetNumber = 999,
    };

    [Inject]
    private Game game;

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
        var actorsNearBy = this.range.Grids((this.owner.X, this.owner.Y), (0, 0))
            .Select((x) => this.game.World.GetMonsterAt(x.Item1, x.Item2))
            .Count(m => m != null);
        args.attackData.buffConst += (actorsNearBy / this.actorNum) * this.gain;
    }
}
