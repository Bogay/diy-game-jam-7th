using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Model;


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

    public override CastResult Cast(Game game, Actor actor)
    {

        if (targetBuffs.Count != 0)
        {
            List<Monster> targets = new List<Monster>();
            (int, int) source = (actor.X, actor.Y);
            // TODO: get forward vector from actor
            (int, int) forward = (0, 1);
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
                return CastResult.Failed;
            }

            foreach (Monster target in targets)
            {
                foreach (var buff in this.targetBuffs)
                {
                    target.AddBuff(ScriptableObject.Instantiate(buff));
                }
            }
        }


        foreach (var buff in this.ownerBuffs)
        {
            actor.AddBuff(ScriptableObject.Instantiate(buff));
        }

        // TODO: show dialogue
        return CastResult.Success;
    }
}
