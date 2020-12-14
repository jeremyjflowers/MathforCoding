using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Laser : Actor
    {
        private Sprite _sprite;
        private float _speed = 8;

        public Laser(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {

        }

        public Laser(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Red) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/bulletDark3_outline.png");
        }

        public override void Draw()
        {
            _sprite.Draw(_localTransform);
            base.Draw();
        }
    }
}
