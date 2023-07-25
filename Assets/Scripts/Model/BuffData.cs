using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

[System.Serializable]
public class BuffViewData
{
    public Sprite Sprite;
    public string Description;
}

public class BuffData : ScriptableObject
{
    // won't be rendered on UI if set to null
    public BuffViewData viewData;

    [Tooltip("Notes for dev. Won't affect game logic")]
    [SerializeField]
    private string devNote;

    public virtual void OnAttaching(Actor actor)
    {
        Debug.Log($"Attach to {actor.Name}");
    }

    public virtual void OnDetached(Actor actor)
    {
        Debug.Log($"Detached from {actor.Name}");
    }
}
