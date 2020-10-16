using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Golf : Entity
    {
        public Golf(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x,y,icon)
        {

        }

        public void Collision()
        {

        }

        public override void Draw()
        {

            base.Draw();
        }
    }
}
