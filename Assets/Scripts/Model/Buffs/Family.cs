using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniDi;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using System.Linq;

[CreateAssetMenu(menuName = "SO/Buff/Family")]
public class Family : BuffData
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
        actor.Game.TurnEnded += this.onTurnEnded;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.Game.TurnEnded -= this.onTurnEnded;
    }

    private void onTurnEnded(object sender, TurnEndedEventArgs args)
    {
        var hasFamilyNearBy = this.range.Grids((this.owner.X, this.owner.Y), (0, 0))
            .Select((x) => this.game.World.GetMonsterAt(x.Item1, x.Item2))
            .Any(this.isFamily);
        if (hasFamilyNearBy)
        {
            this.owner.Health += this.value;
        }
    }

    private bool isFamily(Actor actor)
    {
        var targets = new CharacterSO.SexualCharacteristics[] {
            CharacterSO.SexualCharacteristics.哥哥,
            CharacterSO.SexualCharacteristics.妹妹,
            CharacterSO.SexualCharacteristics.姊姊,
            CharacterSO.SexualCharacteristics.人妻,
        };

        return actor.actorData.sexualCharacteristicsList.Any(s => targets.Contains(s));
    }
}
