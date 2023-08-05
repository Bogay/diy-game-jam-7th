using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.View;
using UnityEngine;

public class SkillNoInputController : ISkillInputController
{
    public (InputState, InputCommands) GetInput() => (InputState.Normal, InputCommands.CastSkill);
}
