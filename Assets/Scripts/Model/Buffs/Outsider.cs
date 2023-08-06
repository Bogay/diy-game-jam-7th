using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/Outsider")]
public class Outsider : BuffData
{
    [SerializeField]
    private int value;

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
        actor.OnRest += this.onRest;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnRest += this.onRest;
    }

    private void onRest(object sender, RestArgs args)
    {
        foreach (var (x, y) in this.range.Grids((args.Actor.X, args.Actor.Y), (0, 0)))
        {
            if (this.game.World.GetMonsterAt(x, y) != null)
            {
                return;
            }
        }

        args.Value.buffConst += this.value;
    }
}
