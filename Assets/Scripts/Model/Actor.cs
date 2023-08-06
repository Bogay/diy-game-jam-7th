using System;
using System.Collections;
using System.Collections.Generic;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Model.Interfaces;
using RogueSharp;
using UniDi;
using UnityEngine;

namespace RogueSharpTutorial.Model
{
    public class Actor : IActor, IDrawable, IScheduleable
    {
        public event UpdateAttack OnAttack;
        public event UpdateAttack OnDefense;
        // FIXME: add type for this event
        public event UpdateAttack OnMove;

        // TODO: naming
        // it is ued to update attacker / defender properties, we may need to use another type
        public event UpdateAttack OnDamaged;
        public event RestEventHandler OnRest;

        private List<BuffData> buffs;

        // configure stats for each character
        public CharacterSO actorData { get; private set; }

        // TODO: maybe some setters are not required

        // IActor
        private int attack;
        public int Attack
        {
            get => this.actorData.m_Attack;
            set { }
        }
        private int attackChance;
        public int AttackChance
        {
            get { return attackChance; }
            set { attackChance = value; }
        }
        private CharacterSO.Gender gender;
        public CharacterSO.Gender Gender
        {
            get => this.actorData.m_gender;
            set { /* TODO: maybe the setter is not required */ }
        }
        private int defense;
        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }
        private int defenseChance;
        public int DefenseChance
        {
            get { return defenseChance; }
            set { defenseChance = value; }
        }
        private int gold;
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        private int health;
        public int Health
        {
            get { return health; }
            set { health = Math.Clamp(value, 0, MaxHealth); }
        }
        private int maxHealth;
        public int MaxHealth
        {
            get { return this.actorData.m_Max_HP; }
            set { maxHealth = value; }
        }
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private string name;
        public string Name
        {
            get => this.actorData.m_name.ToString();
            set { name = value; }
        }
        private int awareness;
        public int Awareness
        {
            get { return 10; }
            set { awareness = value; }
        }

        // IDrawable
        public Colors Color { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Ischeduleable
        public int Time
        {
            get { return Speed; }
        }

        protected Game game;

        // TODO: add getter here might not be a good idea?
        public Game Game => this.game;

        public Skill Skill { get; private set; }

        private int forwardX;
        private int forwardY;
        public (int, int) Forward
        {
            get => (this.forwardX, this.forwardY);
            set => (this.forwardX, this.forwardY) = value;
        }

        public Actor(Game game, CharacterSO characterSO, DiContainer container)
        {
            this.game = game;
            this.buffs = new List<BuffData>();
            this.actorData = characterSO;
            if (this.actorData.skillData != null)
            {
                this.Skill = container.Instantiate<Skill>(new object[] {
                    ScriptableObject.Instantiate(this.actorData.skillData),
                    this // owner
                });
            }
            this.health = this.MaxHealth;
        }

        public void Draw(IMap map)
        {
            // Only draw the actor with the color and symbol when they are in field-of-view
            if (map.IsInFov(X, Y))
            {
                game.SetMapCell(
                    X,
                    Y,
                    Color,
                    Colors.FloorBackgroundFov,
                    Symbol,
                    map.GetCell(X, Y).IsExplored
                );
            }
            else
            {
                // When not in field-of-view just draw a normal floor
                game.SetMapCell(
                    X,
                    Y,
                    Colors.Floor,
                    Colors.FloorBackground,
                    '.',
                    map.GetCell(X, Y).IsExplored
                );
            }
        }

        public void PrepareAttack(Actor defender, AttackData attackData)
        {
            if (this.OnAttack == null)
                return;

            this.OnAttack(
                this,
                new UpdateAttackArgs
                {
                    attacker = this,
                    defender = defender,
                    attackData = attackData,
                }
            );
        }

        public void PrepareDefense(Actor attacker, AttackData attackData)
        {
            if (this.OnDefense == null)
                return;

            this.OnDefense(
                this,
                new UpdateAttackArgs
                {
                    attacker = attacker,
                    defender = this,
                    attackData = attackData,
                }
            );
        }

        public void ResolveDamage(AttackData attackData)
        {
            if (this.OnDamaged == null)
                return;

            this.OnDamaged(
                this,
                new UpdateAttackArgs
                {
                    attacker = null,
                    defender = this,
                    attackData = attackData,
                }
            );
        }

        public void AddBuff(BuffData buff)
        {
            this.buffs.Add(buff);
            buff.OnAttaching(this);
        }

        public bool RemoveBuff(BuffData buff)
        {
            int idx = this.buffs.IndexOf(buff);
            if (idx == -1)
                return false;
            this.buffs.RemoveAt(idx);
            buff.OnDetached(this);
            return true;
        }

        public void ResolveRest(AttackData restData)
        {
            this.OnRest?.Invoke(this, new RestArgs { Actor = this, Value = restData, });
        }

        public AttackData ResolveMove()
        {
            AttackData attackData = new AttackData(0);
            this.OnMove?.Invoke(this, new UpdateAttackArgs { attacker = this, defender = null, attackData = attackData });
            return attackData;
        }
    }
}
