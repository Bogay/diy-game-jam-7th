using System;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;

public class Skill
{
    private Game game;
    private Actor owner;
    private SkillData skillData;

    public int CurrentCoolDown { get; private set; }
    public int CoolDown => this.skillData.CoolDown;
    public string SkillName => this.skillData.SkillName;
    public string Description => this.skillData.Description;

    public Skill(Actor owner, SkillData skillData, Game game)
    {
        this.owner = owner;
        this.skillData = skillData;
        this.CurrentCoolDown = 0;
        this.game = game;
        this.game.TurnEnded += this.onTurnEnded;
    }

    public virtual bool CanCast()
    {
        return this.CurrentCoolDown <= 0;
    }

    public virtual CastResult Cast()
    {
        CastResult result = this.skillData.Cast(this.game, this.owner);
        if (result == CastResult.Success)
        {
            // HACK: +1 because the cool down decreases immediately
            this.CurrentCoolDown = this.CoolDown + 1;
        }
        return result;
    }

    private void onTurnEnded(object sender, TurnEndedEventArgs args)
    {
        this.CurrentCoolDown = Math.Max(0, this.CurrentCoolDown - 1);
    }
}
