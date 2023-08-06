using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniDi;
using RogueSharpTutorial.Model;

[CreateAssetMenu(menuName = "SO/Buff/SexualCharacteristics")]
public class SexualCharacteristicsSO : BuffData
{
    [SerializeField]
    private List<BuffData> buffs;

    [Inject]
    private BuffData.Factory factory;

    private List<BuffData> buffInstances;

    public override void OnAttaching(Actor actor)
    {
        base.OnAttaching(actor);
        this.buffInstances = new List<BuffData>();
        foreach (var buff in buffs)
        {
            var b = this.factory.Create(buff);
            this.buffInstances.Add(b);
            actor.AddBuff(b);
        }
    }
}
