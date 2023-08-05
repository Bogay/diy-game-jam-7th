using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/CreateAttack")]
public class CreateAttack : BuffData
{
    private Actor source;
    private CommandSystem commandSystem;

    [Inject]
    private void Init([Inject(Id = "source")] Actor source, CommandSystem commandSystem)
    {
        this.source = source;
        this.commandSystem = commandSystem;
        Debug.Log("Initialized: CreateAttack");
    }

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        this.commandSystem.Attack(this.source, actor);
        actor.RemoveBuff(this);
    }
}
