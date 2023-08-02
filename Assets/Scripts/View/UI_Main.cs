﻿using System;
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

        [SerializeField]
        private CharacterSO[] sprites;

        [Inject]
        private DiContainer container;

        private Game game;
        private TileUnity[,] mapObjects;

        [Inject]
        private CharaBinder.CharaSelect charaSelect;

        [Inject]
        private CharaBinder.PlayerChara playerChara;

        private void Start()
        {
            //uiInventory     = GetComponent<UI_Inventory>();
            uiStats = GetComponent<UI_Stats>();
            uiMessages = GetComponent<UI_Messages>();
            inputKeyboard = GetComponent<InputKeyboard>();
            // game = new Game(this);
            // container.Inject(game);
            game = this.container.Instantiate<Game>();
            Debug.Log(playerChara.currentSelect);
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

        public void UpdateMapCell(
            int x,
            int y,
            Colors foreColor,
            Colors backColor,
            char symbol,
            bool isExplored
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

                tile.TileActive = isExplored;
                tile.BackgroundColor = ColorMap.UnityColors[backColor];
                tile.Text = symbol;
                tile.TextColor = ColorMap.UnityColors[foreColor];

                tile.IsAsciiTile = false;
                if (int.TryParse(symbol.ToString(), out int symbolNum))
                {
                    tile.SpriteImage = charaSelect.characterSOs[symbolNum].m_sprite;
                    tile.SpriteImageOrder = 1;
                }
                else
                {
                    switch (symbol)
                    {
                        case '@':
                            tile.SpriteImage = charaSelect.characterSOs[
                                playerChara.currentSelect
                            ].m_sprite;
                            tile.SpriteImageOrder = 1;
                            break;
                        case 'k':
                            tile.SpriteImage = sprites[2].m_sprite;
                            tile.SpriteImageOrder = 1;
                            break;
                        default:
                            tile.SpriteImage = sprites[0].m_sprite;
                            tile.SpriteImageOrder = 0;
                            break;
                    }
                }
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
