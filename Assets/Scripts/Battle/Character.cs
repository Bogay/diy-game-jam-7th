using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterData data;

    public int MaxHP => this.data.MaxHP;
    public int HP { get; private set; }
    public int Attack => this.data.Attack;
    public int Defense => this.data.Defense;

    // pos on grid map
    private Vector2 pos;

    public void TakeDamage(int damage)
    {
        damage = Mathf.Max(0, damage - this.Defense);
        this.HP -= damage;
        if (this.HP <= 0)
        {
            // TODO: emit event
        }
    }
}
