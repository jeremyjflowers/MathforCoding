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

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            //Creates a new window for raylib
            Raylib.InitWindow(1152, 864, "Math For Games");
            Console.CursorVisible = false;
            Scene scene1 = new Scene();
            Scene scene2 = new Scene();

            Player player = new Player(5, 7, Color.GOLD, '@', ConsoleColor.Yellow);
            Enemy enemy = new Enemy(15, 15, Color.BLUE, '☼', ConsoleColor.Red);
            scene1.AddEntity(player);
            scene1.AddEntity(enemy);
            enemy.Target = player;
            enemy.Translate(new Vector2(15, 15));
            enemy.Scale(2, 2);
            player.Translate(new Vector2(5,7));
            player.Rotate(1);
            player.Scale(2, 3);


            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            SetCurrentScene(startingSceneIndex);
        }

        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
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

        //Handles all of the main game logic including the main game loop.
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
