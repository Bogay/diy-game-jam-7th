using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/KnockBack")]
public class KnockBack : BuffData
{
    private Actor source;
    private CommandSystem commandSystem;

    [Inject]
    private void Init([Inject(Id = "source")] Actor source, CommandSystem commandSystem)
    {
        this.source = source;
        this.commandSystem = commandSystem;
        Debug.Log("Initialized: KnockBack");
    }

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        int newX = actor.X + this.source.Forward.Item1;
        int newY = actor.Y + this.source.Forward.Item2;
        this.commandSystem.MoveTo(actor, newX, newY);
        actor.RemoveBuff(this);
    }
}
