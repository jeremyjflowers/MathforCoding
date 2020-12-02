using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Turret : Actor
    {
        private Sprite _sprite;

        public Turret(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta) : base(x, y, icon, color)
        {

        }

        public Turret(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/tank_dark.png");
        }

        public override void Update(float deltaTime)
        {

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_localTransform);
            base.Draw();
        }
    }
}
