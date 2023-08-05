using UnityEngine;
using UniRx;
using UniDi;
using RogueSharpTutorial.Controller;

namespace RogueSharpTutorial.View
{
    public enum InputState
    {
        Normal,
        PrepareSkill,
    }

    public class InputKeyboard : MonoBehaviour
    {
        // FIXME: do not use extra flag to store state
        private bool restFlag;
        private bool skillFlag;

        private InputCommands input;
        private bool skipRefresh;
        private InputState state = InputState.Normal;
        private ISkillInputController skillInputController;

        [Inject]
        private Game game;

        /// <summary>
        /// Will return the last keyboard up pressed. Will then clear the input to None.
        /// </summary>
        public InputCommands Command
        {
            get
            {
                InputCommands returnVal = input;
                input = InputCommands.None;
                return returnVal;
            }
        }

        private void Start()
        {
            Observable.Interval(System.TimeSpan.FromMilliseconds(300))
                .Subscribe(_ =>
                {
                    if (this.skipRefresh)
                    {
                        this.skipRefresh = false;
                        return;
                    }

                    this.input = InputCommands.None;
                    this.restFlag = false;
                    this.skillFlag = false;
                })
                .AddTo(this);
        }

        private void Update()
        {
            var (newState, newInput) = GetKeyboardValue();
            if (newInput != InputCommands.None)
            {
                this.skipRefresh = true;
            }
            this.input = newInput;
            this.state = newState;
        }

        public void PrepareSkill()
        {
            if (!this.game.IsPlayerTurn)
                return;
            this.skillFlag = true;
        }

        public void Rest()
        {
            if (!this.game.IsPlayerTurn)
                return;
            this.restFlag = true;
        }

        private (InputState, InputCommands) GetKeyboardValue()
        {
            // handle prepare skill state
            if (this.state == InputState.PrepareSkill)
            {
                Debug.Assert(this.skillInputController != null);
                var (state, cmd) = this.skillInputController.GetInput();
                // dispose input controller
                if (cmd == InputCommands.CastSkill)
                {
                    this.skillInputController = null;
                }
                return (state, cmd);
            }

            if (this.GetUpInput())
            {
                return (InputState.Normal, InputCommands.Up);
            }
            else if (this.GetLeftInput())
            {
                return (InputState.Normal, InputCommands.Left);
            }
            else if (this.GetRightInput())
            {
                return (InputState.Normal, InputCommands.Right);
            }
            else if (this.GetDownInput())
            {
                return (InputState.Normal, InputCommands.Down);
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                return (InputState.Normal, InputCommands.CloseGame);
            }
            else if (Input.GetKeyUp(KeyCode.Space) || this.restFlag)
            {
                this.restFlag = false;
                return (InputState.Normal, InputCommands.Rest);
            }
            else if (this.getPrepareSkillInput())
            {
                Debug.Log($"Prepare skill: {this.game.Player.Skill.SkillName}");
                this.skillFlag = false;
                this.skillInputController = this.game.Player.Skill.GetInputController();
                return (InputState.PrepareSkill, InputCommands.None);
            }

            return (InputState.Normal, InputCommands.None);
        }

        public bool GetUpInput() => Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.UpArrow);
        public bool GetDownInput() => Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.DownArrow);
        public bool GetLeftInput() => Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow);
        public bool GetRightInput() => Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow);

        private bool getPrepareSkillInput()
        {
            if (this.game?.Player.Skill == null)
                return false;
            if (this.game?.IsPlayerTurn != true)
                return false;
            return Input.GetKeyUp(KeyCode.LeftControl) || this.skillFlag;
        }
    }
}
