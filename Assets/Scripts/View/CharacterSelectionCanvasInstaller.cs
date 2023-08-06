using UnityEngine;
using UniDi;

public class CharacterSelectionCanvasInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject tooltip;

    public override void InstallBindings()
    {
        Container.BindInstance(this.tooltip).WithId("tooltip").WhenInjectedInto<SelectedSexualCharacteristicPanel>();
    }
}
