using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Bullet : Actor
    {
        private Sprite _sprite;

        public Bullet(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, icon, color)
        {

        }

        public Bullet(float x, float y, ConsoleColor rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, icon, color)
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
