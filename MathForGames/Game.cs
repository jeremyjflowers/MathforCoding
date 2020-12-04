using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        
        public static int CurrentSceneIndex
        {
            get { return _currentSceneIndex; }
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene GetScenes(int index)
        {
            return _scenes[index];
        }

        //
        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        //
        public static bool RemoveSecne(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for(int i = 0; i > _scenes.Length; i++)
            {
                if(tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                }
            }

            if (removed)
                _scenes = tempArray;

            return removed;
        }

        //
        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            _currentSceneIndex = index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        /// <summary>
        /// Called when the game begins. Use this for initialization.
        /// </summary>
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1280, 768, "MathForGames");
            Raylib.EnableCursor();
            Raylib.ShowCursor();
            Scene scene1 = new Scene();

            Tank tank = new Tank(10, 10, Color.SKYBLUE, '@', ConsoleColor.Cyan);
            Turret turret = new Turret(10, 10, Color.BROWN, '$', ConsoleColor.Gray);
            Enemy enemy1 = new Enemy(15, 10, Color.GOLD, '!', ConsoleColor.Blue);
            Enemy enemy2 = new Enemy(18, 10, Color.GOLD, '!', ConsoleColor.Blue);
            Enemy enemy3 = new Enemy(21, 10, Color.GOLD, '!', ConsoleColor.Blue);
            Enemy enemyBullet = new Enemy(15, 12, Color.BEIGE, '+', ConsoleColor.DarkBlue);
            scene1.AddActor(tank);
            scene1.AddActor(turret);
            scene1.AddActor(enemy1);
            scene1.AddActor(enemy2);
            scene1.AddActor(enemy3);
            enemy1.AddChild(enemyBullet);
            tank.AddChild(turret);
            tank.Speed = 4;
            tank.SetTranslate(new Vector2(10, 20));
            enemy1.SetTranslate(new Vector2(30, 5));
            enemy1.SetScale(3.5f, 3.5f);
            enemy2.SetTranslate(new Vector2(20, 5));
            enemy2.SetScale(3.5f, 3.5f);
            enemy3.SetTranslate(new Vector2(10, 5));
            enemy3.SetScale(3.5f, 3.5f);
            enemy1.Target = tank;
            enemy2.Target = tank;
            enemy3.Target = tank;

            int startingSceneIndex = 0;
            startingSceneIndex = AddScene(scene1);
            SetCurrentScene(startingSceneIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();
            Raylib.EndDrawing();
        }

        //Called when the game ends.
        public void End()
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }

        /// <summary>
        /// Handles all of the main game logic including the main game loop.
        /// </summary>
        public void Run()
        {
            Start();

            while(!_gameOver && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}
