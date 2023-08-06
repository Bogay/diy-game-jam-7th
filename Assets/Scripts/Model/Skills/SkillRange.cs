using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillDirection
{
    Forward,
    Self,
    Around,
}

[System.Serializable]
public class SkillRange
{
    public SkillDirection Direction;
    public int Distance;
    public int MaxTargetNumber;

    public IEnumerable<(int, int)> Grids((int, int) source, (int, int) forward)
    {
        switch (this.Direction)
        {
            case SkillDirection.Forward:
                (int, int) cursor = source;
                for (int i = 0; i < this.Distance; i++)
                {
                    cursor.Item1 += forward.Item1;
                    cursor.Item2 += forward.Item2;
                    yield return cursor;
                }
                break;
            case SkillDirection.Self:
                yield return source;
                break;
            case SkillDirection.Around:
                // TODO
                break;
            default:
                yield return source;
                break;
        }
    }
}
