using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData
{
    public bool isEffective;
    public int originalValue;
    public int buffRatio;
    public int buffConst;

    public int Value => this.originalValue * (100 + this.buffRatio) / 100 + this.buffConst;

    public AttackData(int value)
    {
        this.isEffective = true;
        this.originalValue = value;
        this.buffRatio = 0;
        this.buffConst = 0;
    }
}
