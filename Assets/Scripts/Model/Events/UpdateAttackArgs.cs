using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Model;

public class UpdateAttackArgs : EventArgs
{
    public Actor attacker;
    public Actor defender;
    public AttackData attackData;
}

public delegate void UpdateAttack(object sender, UpdateAttackArgs args);
