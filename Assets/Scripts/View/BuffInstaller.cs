using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniDi;

public class BuffInstaller : MonoInstaller
{
    [SerializeField]
    private List<BuffData> staticBuffs;

    public override void InstallBindings()
    {
        Container.BindInstance(this.staticBuffs).WithId("static");
        Debug.Log("Buff installed");
    }
}
