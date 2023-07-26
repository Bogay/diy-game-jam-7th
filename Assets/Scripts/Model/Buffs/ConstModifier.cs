using UnityEngine;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/ConstModifier")]
public class ConstModifier : BuffData
{
    [SerializeField]
    private int attack;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int receivedDamage;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        actor.OnAttack += this.onAttack;
        actor.OnDefense += this.onDefense;
    }

    public override void OnDetached(Actor actor)
    {
        base.OnDetached(actor);
        actor.OnAttack -= this.onAttack;
        actor.OnDefense -= this.onDefense;
    }

    private void onAttack(object sender, UpdateAttackArgs args)
    {
        args.attackData.originalValue += this.attack;
        args.attackData.buffConst += this.damage;
    }

    private void onDefense(object sender, UpdateAttackArgs args)
    {
        args.attackData.buffConst -= this.receivedDamage;
    }
}
