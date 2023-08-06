using System;
using System.Collections.Generic;
using RogueSharpTutorial.View;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Utilities;
using RogueSharp.Random;
using UniDi;

namespace RogueSharpTutorial.Controller
{
    public class Game
    {
        public TurnEnded TurnEnded;

        public static IRandom Random { get; private set; }

        private UI_Main rootConsole;
        private InputKeyboard inputControl;

        private CommandSystem commandSystem;
        private static readonly int mapWidth = 80;
        private static readonly int mapHeight = 48;
        private bool renderRequired = true;

        public MessageLog MessageLog { get; set; }
        public DungeonMap World { get; private set; }
        public Player Player { get; set; }
        public SchedulingSystem SchedulingSystem { get; private set; }
        public bool IsPlayerTurn => this.commandSystem.IsPlayerTurn;

        public int mapLevel = 1;

        private List<BuffData> staticBuffs;
        private DiContainer container;

        public Game(
            UI_Main console,
            DiContainer container,
            [Inject(Id = "static")] List<BuffData> staticBuffs
        )
        {
            container.BindInstance(this);

            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);
            commandSystem = new CommandSystem(this);
            MessageLog = new MessageLog(this);
            SchedulingSystem = new SchedulingSystem();

            container.BindInstance(commandSystem);

            rootConsole = console;
            rootConsole.UpdateView += OnUpdate; // Set up a handler for graphic engine Update event

            MessageLog.Add("The rogue arrives on level " + mapLevel);
            MessageLog.Add("Level created with seed '" + seed + "'");

            this.container = container;
            this.staticBuffs = staticBuffs;
        }

        public void Init()
        {
            GenerateMap();
            rootConsole.SetPlayer(Player);
            World.UpdatePlayerFieldOfView(Player);
            Draw();
        }

        public void SetMapCellOverlay(int x, int y, Colors overlayColor)
        {
            this.rootConsole.UpdateMapCellOverlay(x, y, overlayColor);
        }

        public void SetMapCell(
            int x,
            int y,
            Colors foreColor,
            Colors backColor,
            char symbol,
            bool isExplored
        )
        {
            rootConsole.UpdateMapCell(x, y, foreColor, backColor, symbol, isExplored);
        }

        public void PostMessageLog(Queue<string> messages, Colors color)
        {
            rootConsole.PostMessageLog(messages, color);
        }

        public void DrawPlayerStats()
        {
            rootConsole.DrawPlayerStats();
        }

        public void DrawMonsterStats(Monster monster, int position)
        {
            rootConsole.DrawMonsterStats(monster, position);
        }

        public void ClearMonsterStats()
        {
            rootConsole.ClearMonsterStats();
        }

        private void OnUpdate(object sender, UpdateEventArgs e)
        {
            CheckKeyboard();

            if (renderRequired)
            {
                Draw();
                renderRequired = false;
            }
        }

        // FIXME: do not call constructor of MonoBehaviour
        private void GenerateMap()
        {
            MapGenerator mapGenerator = new MapGenerator(
                this,
                mapWidth,
                mapHeight,
                20,
                13,
                7,
                mapLevel
            );
            this.container.Inject(mapGenerator);

            World = mapGenerator.CreateMap();
            rootConsole.GenerateMap(World);
        }

        public void Draw()
        {
            World.Draw();
            Player.Draw(World);
            Player.DrawStats();
            MessageLog.Draw();
        }

        private void CheckKeyboard()
        {
            bool didPlayerAct = false;

            if (commandSystem.IsPlayerTurn)
            {
                InputCommands command = rootConsole.GetUserCommand();
                switch (command)
                {
                    case InputCommands.UpLeft:
                        didPlayerAct = commandSystem.MovePlayer(Direction.UpLeft);
                        break;
                    case InputCommands.Up:
                        didPlayerAct = commandSystem.MovePlayer(Direction.Up);
                        break;
                    case InputCommands.UpRight:
                        didPlayerAct = commandSystem.MovePlayer(Direction.UpRight);
                        break;
                    case InputCommands.Left:
                        didPlayerAct = commandSystem.MovePlayer(Direction.Left);
                        break;
                    case InputCommands.Right:
                        didPlayerAct = commandSystem.MovePlayer(Direction.Right);
                        break;
                    case InputCommands.DownLeft:
                        didPlayerAct = commandSystem.MovePlayer(Direction.DownLeft);
                        break;
                    case InputCommands.Down:
                        didPlayerAct = commandSystem.MovePlayer(Direction.Down);
                        break;
                    case InputCommands.DownRight:
                        didPlayerAct = commandSystem.MovePlayer(Direction.DownRight);
                        break;
                    case InputCommands.StairsDown:
                        if (World.CanMoveDownToNextLevel())
                        {
                            MoveMapLevelDown();
                            didPlayerAct = true;
                        }
                        break;
                    case InputCommands.CloseGame:
                        rootConsole.CloseApplication();
                        break;
                    case InputCommands.CastSkill:
                        didPlayerAct = commandSystem.CastSkill(this.Player);
                        break;
                    case InputCommands.Rest:
                        didPlayerAct = commandSystem.Rest(this.Player);
                        break;
                    default:
                        break;
                }

                if (didPlayerAct)
                {
                    renderRequired = true;
                    commandSystem.EndPlayerTurn();
                    this.TurnEnded?.Invoke(this, new TurnEndedEventArgs());
                }
            }
            else
            {
                commandSystem.ActivateMonsters();
                renderRequired = true;
            }
        }

        private void MoveMapLevelDown()
        {
            rootConsole.ClearMap();
            MapGenerator mapGenerator = new MapGenerator(
                this,
                mapWidth,
                mapHeight,
                20,
                13,
                7,
                ++mapLevel
            );
            World = mapGenerator.CreateMap();
            rootConsole.GenerateMap(World);
            rootConsole.SetPlayer(Player);
            World.UpdatePlayerFieldOfView(Player);
            Draw();
            MessageLog = new MessageLog(this);
            commandSystem = new CommandSystem(this);
        }

    }
}
