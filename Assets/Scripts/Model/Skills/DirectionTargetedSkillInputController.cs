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
    private Game game;
    [Inject]
    private Skill skill;
    [Inject]
    private InputKeyboard inputKeyboard;

    public (InputState, InputCommands) GetInput()
    {
        var nop = (InputState.PrepareSkill, InputCommands.None);
        if (this.inputKeyboard.GetUpInput())
        {
            this.updateForward((0, 1));
            return nop;
        }
        else if (this.inputKeyboard.GetDownInput())
        {
            this.updateForward((0, -1));
            return nop;
        }
        else if (this.inputKeyboard.GetLeftInput())
        {
            this.updateForward((-1, 0));
            return nop;
        }
        else if (this.inputKeyboard.GetRightInput())
        {
            this.updateForward((1, 0));
            return nop;
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            this.updateForward((0, 0));
            Debug.Log($"Cancel skill casting: {this.skill.SkillName}");
            return (InputState.Normal, InputCommands.None);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log($"Cast skill: {this.skill.SkillName}");
            return (InputState.Normal, InputCommands.CastSkill);
        }
        return nop;
    }

    private void updateForward((int, int) vec)
    {
        this.skill.Owner.Forward = vec;
        this.draw();
    }

    private void draw()
    {
        this.game.Draw();
        if (this.skill.Owner.Forward != (0, 0))
        {
            var grids = this.skill.SkillData.Range.Grids((this.skill.Owner.X, this.skill.Owner.Y), this.skill.Owner.Forward);
            foreach (var (x, y) in grids)
            {
                this.game.SetMapCellOverlay(x, y, Colors.Gold);
            }
        }
    }
}
