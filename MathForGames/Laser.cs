using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Laser : Actor
    {
        private Vector2 _position = new Vector2();
        private Vector2 _direction = new Vector2();
        private Sprite _sprite;
        private float _speed = 8;

        public Laser(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.DarkBlue) : base(x, y, icon, color)
        {

        }

        public Laser(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.DarkBlue) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/bulletDark3_outline.png");
        }
    }
}
