using RogueSharpTutorial.View;
using RogueSharpTutorial.Controller;

using UnityEngine;
using UniDi;

namespace RogueSharpTutorial.Model
{
    public class Player : Actor
    {
        public Player(Game game, CharacterSO characterSO, DiContainer container) : base(game, characterSO, container)
        {
            Symbol = '@';
        }

        // public Player(Game game, CharacterSO characterSO)
        //     : base(game, characterSO)
        // {
        //     Attack = 2;
        //     AttackChance = 50;
        //     Awareness = 10;
        //     Color = Colors.Player;
        //     Defense = 2;
        //     DefenseChance = 40;
        //     Gold = 0;
        //     Health = 100;
        //     MaxHealth = 100;
        //     Name = "Rogue";
        //     Speed = 10;
        //     Symbol = '@';
        // }

        public void DrawStats()
        {
            game.DrawPlayerStats();
        }
    }
}
