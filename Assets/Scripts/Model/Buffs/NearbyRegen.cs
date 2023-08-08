using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using System.Linq;
using UniDi;

[CreateAssetMenu(menuName = "SO/Buff/NearbyRegen")]
public class NearbyRegen : BuffData
{
    [SerializeField]
    private bool matchAll;
    [SerializeField]
    private CharacterSO.SexualCharacteristics target;
    [SerializeField]
    private int distance;
    [SerializeField]
    private int healAmount;

    [Inject]
    private Game game;

    private SkillRange range => new SkillRange
    {
        Direction = SkillDirection.Around,
        Distance = this.distance,
        MaxTargetNumber = 10086,
    };

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);

        int matchedNumber = this.range.Grids((actor.X, actor.Y), (0, 0))
            .Select((xy) => this.game.World.GetMonsterAt(xy.Item1, xy.Item2))
            .Where(m => m != null)
            .Count(m => this.matchAll || m.actorData.sexualCharacteristicsList.Contains(this.target));
        actor.Health += this.healAmount * matchedNumber;

        actor.RemoveBuff(this);
    }
}
