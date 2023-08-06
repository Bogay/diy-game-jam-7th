using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.View;

public interface ISkillInputController
{
    public (InputState, InputCommands) GetInput();
}
