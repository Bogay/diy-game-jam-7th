using RogueSharpTutorial.Controller;
using UnityEngine;
using UniDi;

namespace RogueSharpTutorial.Model
{
    public class Monster : Actor
    {
        public int? TurnsAlerted { get; set; }

        public Monster(Game game, CharacterSO characterSO, DiContainer container)
            : base(game, characterSO, container) { }

        public void DrawStats(int position)
        {
            game.DrawMonsterStats(this, position);
        }

        public virtual void PerformAction(CommandSystem commandSystem)
        {
            var behavior = new StandardMoveAndAttack();
            behavior.Act(this, commandSystem, game);
        }
    }
}
