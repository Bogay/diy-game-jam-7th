using UnityEngine;
using UniDi;
using RogueSharpTutorial.View;

public class MainUIInstaller : MonoInstaller
{
    [SerializeField]
    private UI_Main uI_Main;

    public override void InstallBindings()
    {
        Container.BindInstance(this.uI_Main).AsSingle();
        Container.QueueForInject(this.uI_Main);
        Debug.Log("Main UI installed");
    }
}