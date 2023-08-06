using UnityEngine;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/NTR")]
public class NTR : BuffData
{
    [SerializeField]
    private int value;

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
        if (args.defender.actorData.sexualCharacteristicsList.Contains(CharacterSO.SexualCharacteristics.人妻))
        {
            args.attackData.buffConst += this.value;
        }
    }
}
