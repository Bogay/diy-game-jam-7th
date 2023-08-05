using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using UniDi;

[System.Serializable]
public struct BuffViewData
{
    public Sprite Sprite;
    public string Description;
    [Tooltip("whether it should be displayed on UI")]
    public bool show;
}

public class BuffDataFactory : IFactory<BuffData, BuffData>
{
    private DiContainer container;

    public BuffDataFactory(DiContainer container)
    {
        this.container = container;
    }

    public BuffData Create(BuffData buffData)
    {
        // // TODO: can this be used on SO?
        // return this.container.InstantiatePrefabForComponent<BuffData>(buffData);
        var newBuffData = ScriptableObject.Instantiate(buffData);
        this.container.Inject(newBuffData);
        return newBuffData;
    }
}


public class BuffData : ScriptableObject
{
    public class Factory : PlaceholderFactory<BuffData, BuffData> { }

    public BuffViewData viewData;
    public int ttl;

    protected Actor owner;
    protected int life;

    [Tooltip("Notes for dev. Won't affect game logic")]
    [SerializeField]
    private string devNote;

    public virtual void OnAttaching(Actor actor)
    {
        Debug.Log($"Attach {this} to {actor.Name}");
        this.owner = actor;
        if (this.ttl != 0)
        {
            this.life = this.ttl;
            actor.Game.TurnEnded += this.onTurnEnded;
        }
    }

    public virtual void OnDetached(Actor actor)
    {
        Debug.Log($"Detached {this} from {actor.Name}");
        this.owner = null;
        if (this.ttl != 0)
            actor.Game.TurnEnded -= this.onTurnEnded;
    }

    private void onTurnEnded(object sender, TurnEndedEventArgs args)
    {
        this.life--;
        if (this.life <= 0)
        {
            this.owner.RemoveBuff(this);
        }
    }
}
