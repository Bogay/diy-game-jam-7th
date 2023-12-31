using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;

public enum CastResult
{
    Success,
    Failed
}

public class SkillData : ScriptableObject
{
    [SerializeField]
    private SkillRange range;
    public SkillRange Range => this.range;

    public int CoolDown;
    public string SkillName;
    public string Description;

    public virtual CastResult Cast(Game game, Actor actor)
    {
        return CastResult.Success;
    }

    // Default implementation does not require any extra input
    public virtual ISkillInputController GetInputController()
    {
        return new SkillNoInputController();
    }
}
