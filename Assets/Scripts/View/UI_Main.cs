using System;
using System.Collections.Generic;
using UnityEngine;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Utilities;
using RogueSharpTutorial.Model;
using UniDi;

namespace RogueSharpTutorial.View
{
    [System.Serializable]
    public class UI_Main : MonoBehaviour
    {
        public event UpdateEventHandler UpdateView;

        //[SerializeField] private UI_Inventory   uiInventory;
        [SerializeField]
        private UI_Stats uiStats;

        [SerializeField]
        private UI_Messages uiMessages;

        [SerializeField]
        private InputKeyboard inputKeyboard;

        [SerializeField]
        private PlayerCamera playerCamera;

        [SerializeField]
        private TileUnity tilePrefab;

        [Inject]
        private DiContainer container;

        private Game game;
        private TileUnity[,] mapObjects;

        [Inject]
        public CharaBinder.CharaSelect charaSelect;

        [Inject]
        public CharaBinder.PlayerChara playerChara;

        private void Start()
        {
            uiStats = GetComponent<UI_Stats>();
            uiMessages = GetComponent<UI_Messages>();
            game = this.container.Instantiate<Game>();
            Debug.Log($"Currently selected character: {playerChara.currentSelect}");
            inputKeyboard = this.container.InstantiateComponent<InputKeyboard>(gameObject, new object[] { game });

            this.container.BindInstance(this.inputKeyboard);
            this.uiStats.BindInputKeyboard(this.inputKeyboard);

            game.Init();

            this.container.Inject(this.uiStats);
        }

        private void Update()
        {
            UpdateGame();
        }

        private void UpdateGame()
        {
            UpdateView(this, new UpdateEventArgs(Time.time));
        }

        private bool IsInView(Vector3 position)
        {
            Vector3 pointOnScreen = Camera.main.WorldToScreenPoint(position);

            //Is in FOV
            if (
                (pointOnScreen.x < 0)
                || (pointOnScreen.x > Screen.width)
                || (pointOnScreen.y < 0)
                || (pointOnScreen.y > Screen.height)
            )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get the current value of the user input command
        /// </summary>
        /// <returns></returns>
        public InputCommands GetUserCommand()
        {
            return inputKeyboard.Command;
        }

        public void GenerateMap(DungeonMap map)
        {
            mapObjects = new TileUnity[map.Width, map.Height];
        }

        public void ClearMap()
        {
            for (int x = 0; x < mapObjects.GetLength(0); x++)
            {
                for (int y = 0; y < mapObjects.GetLength(1); y++)
                {
                    if (mapObjects[x, y] != null)
                    {
                        mapObjects[x, y].TileActive = false;
                        mapObjects[x, y].ReturnToPool();
                        mapObjects[x, y] = null;
                    }
                }
            }
        }

        public void UpdateMapCellOverlay(int x, int y, Colors overlayColor)
        {
            TileUnity tile = this.mapObjects[x, y];
            if (tile == null)
            {
                Debug.LogWarning($"Update overlay for null tile: ({x}, {y})");
                return;
            }

            var c = ColorMap.UnityColors[overlayColor];
            // HACK: make it semi-transparent
            c.a = 0.5f;
            tile.OverlayColor = c;
        }

        public void UpdateMapCell(
            int x,
            int y,
            Colors foreColor,
            Colors backColor,
            char symbol,
            bool isExplored,
            Colors overlayColor = Colors.Clear
        )
        {
            TileUnity tile;

            if (mapObjects[x, y] != null)
            {
                tile = mapObjects[x, y];
            }
            else
            {
                tile = null;
            }

            if (!IsInView(new Vector3(x, y, 0)))
            {
                if (tile != null)
                {
                    mapObjects[x, y] = null;
                    tile.TileActive = false;
                    tile.ReturnToPool();
                }
            }
            else
            {
                if (tile == null)
                {
                    tile = tilePrefab.GetPooledInstance<TileUnity>();
                    tile.transform.position = new Vector3(x, y, 0);
                    tile.IsAsciiTile = true;
                    mapObjects[x, y] = tile;
                }

                tile.OverlayColor = ColorMap.UnityColors[overlayColor];
                tile.BackgroundColor = ColorMap.UnityColors[backColor];
                tile.Text = symbol;
                tile.TextColor = ColorMap.UnityColors[foreColor];

                tile.IsAsciiTile = true;
                tile.SpriteImageOrder = 0;
                tile.actor = null;

                switch (symbol)
                {
                    case '@':
                        tile.SpriteImage = this.game.Player.actorData.m_sprite;
                        tile.SpriteImageOrder = 1;
                        tile.actor = this.game.Player;
                        tile.IsAsciiTile = false;
                        break;
                    default:

                        Monster monster = this.game.World.GetMonsterAt(x, y);
                        if (monster != null)
                        {
                            tile.SpriteImage = monster.actorData.m_sprite;
                            tile.SpriteImageOrder = 1;
                            tile.actor = monster;
                            tile.IsAsciiTile = false;
                            break;
                        }

                        break;
                }

                tile.TileActive = isExplored;
            }
        }

        public void PostMessageLog(Queue<string> messages, Colors color)
        {
            uiMessages.PostMessageLog(messages, ColorMap.UnityColors[color]);
        }

        public void DrawPlayerStats()
        {
            uiStats.DrawPlayerStats(game);
        }

        public void DrawMonsterStats(Monster monster, int position)
        {
            uiStats.DrawMonsterStats(monster, position);
        }

        public void ClearMonsterStats()
        {
            uiStats.ClearMonsterStats();
        }

        public void SetPlayer(Player player)
        {
            playerCamera.InitCamera(player);
        }

        public void CloseApplication()
        {
            Application.Quit();
        }
    }
}
