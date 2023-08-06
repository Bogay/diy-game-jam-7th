using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RogueSharpTutorial.Model;

public class SkillCastedEventArgs : EventArgs
{
    public Actor Actor;
    public Skill Skill;
    public CastResult Result;
}

public delegate void SkillCasted(object sender, SkillCastedEventArgs args);
