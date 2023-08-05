using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Model;
using UniDi;
using System.Linq;

// General skill data that is suitable for most skill requirement in this game
[CreateAssetMenu(menuName = "SO/SkillData/General")]
public class GeneralSkillData : SkillData
{
    [SerializeField]
    private SkillRange range;
    [SerializeField]
    private List<BuffData> targetBuffs;
    [SerializeField]
    private List<BuffData> ownerBuffs;
    // [SerializeField]
    // private ISkillInputController inputController;

    [Inject]
    private DiContainer container;

    [Inject]
    private BuffData.Factory factory;

    public override CastResult Cast(Game game, Actor actor)
    {
        List<Monster> targets = new List<Monster>();
        if (targetBuffs.Count != 0)
        {
            (int, int) source = (actor.X, actor.Y);
            (int, int) forward = actor.Forward;
            foreach ((int x, int y) in this.range.Grids(source, forward))
            {
                Monster monster = game.World.GetMonsterAt(x, y);
                if (monster != null)
                {
                    targets.Add(monster);
                    if (targets.Count >= this.range.MaxTargetNumber)
                    {
                        break;
                    }
                }
            }

            // No target in skill range
            if (targets.Count == 0)
            {
                foreach (var buff in this.ownerBuffs)
                {
                    actor.AddBuff(this.factory.Create(buff));
                }
                return CastResult.Failed;
            }
        }

        foreach (var buff in this.ownerBuffs)
        {
            actor.AddBuff(this.factory.Create(buff));
        }

        game.MessageLog.Add($"Found {targets.Count} targets.");
        foreach (Monster target in targets)
        {
            foreach (var buff in this.targetBuffs)
            {
                target.AddBuff(this.factory.Create(buff));
            }
        }

        return CastResult.Success;
    }

    public override ISkillInputController GetInputController()
    {
        if (this.range.Direction == SkillDirection.Forward)
            return this.container.Instantiate<DirectionTargetedSkillInputController>();
        return new SkillNoInputController();
    }
}
