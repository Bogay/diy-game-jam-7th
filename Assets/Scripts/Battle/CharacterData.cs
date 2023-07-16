using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    public string Name;
    public int MaxHP;
    public int Attack;
    public int Defense;
}
