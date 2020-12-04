using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Tank : Actor
    {
        private float _speed = 2;
        private Sprite _sprite;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public Tank(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Cyan) : base(x, y, icon, color)
        {

        }

        public Tank(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Cyan) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/tankBody_darkLarge.png");
        }

        public override void Update(float deltaTime)
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_LEFT))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_RIGHT));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_SPACE))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_SPACE));

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
