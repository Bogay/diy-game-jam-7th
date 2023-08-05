using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.View;
using UnityEngine;
using UniDi;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;

public class DirectionTargetedSkillInputController : ScriptableObject, ISkillInputController
{
    [Inject]
    private Skill skill;
    [Inject]
    private InputKeyboard inputKeyboard;

    public (InputState, InputCommands) GetInput()
    {
        if (this.inputKeyboard.GetUpInput())
        {
            this.skill.Owner.Forward = (0, 1);
            return (InputState.PrepareSkill, InputCommands.None);
        }
        else if (this.inputKeyboard.GetDownInput())
        {
            this.skill.Owner.Forward = (0, -1);
            return (InputState.PrepareSkill, InputCommands.None);
        }
        else if (this.inputKeyboard.GetLeftInput())
        {
            this.skill.Owner.Forward = (-1, 0);
            return (InputState.PrepareSkill, InputCommands.None);
        }
        else if (this.inputKeyboard.GetRightInput())
        {
            this.skill.Owner.Forward = (1, 0);
            return (InputState.PrepareSkill, InputCommands.None);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log($"Cancel skill casting: {this.skill.SkillName}");
            return (InputState.Normal, InputCommands.None);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log($"Cast skill: {this.skill.SkillName}");
            return (InputState.Normal, InputCommands.CastSkill);
        }
        return (InputState.PrepareSkill, InputCommands.None);
    }
}
