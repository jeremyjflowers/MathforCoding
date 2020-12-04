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
        private Sprite _bulletSprite = new Sprite("Images/bulletDark3_outline.png");

        public Turret(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Gray) : base(x, y, icon, color)
        {

        }

        public Turret(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Gray) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/tank_dark.png");
        }

        public void FireBullet()
        {
            if(Game.GetKeyDown((int)KeyboardKey.KEY_SPACE))
            {
                _bulletSprite.Draw(_globalTransform);
            }

        }

        public override void Update(float deltaTime)
        {
            FireBullet();
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
