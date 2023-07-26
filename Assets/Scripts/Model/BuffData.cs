using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

[System.Serializable]
public struct BuffViewData
{
    public Sprite Sprite;
    public string Description;
    [Tooltip("whether it should be displayed on UI")]
    public bool show;
}

public class BuffData : ScriptableObject
{
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
