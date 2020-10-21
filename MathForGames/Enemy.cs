using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Entity
    {
        private Entity _target;
        private Color _alertColor;

        public Entity Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow) : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, rayColor, icon, color)
        {
            _alertColor = Color.BLUE;
        }

        public bool CheckTargetInSight()
        {
            if (Target == null)
                return false;

            Vector2 direction = Vector2.Normalize(Position - Target.Position);
            if (Vector2.DotProduct(Forward, direction) == 1)
                return true;

            return false;
        }

        public override void Update(float deltaTime)
        {
            if(CheckTargetInSight())
            {
                _rayColor = Color.BLUE;
            }
            else
            {
                _rayColor = Color.RED;
            }

            base.Update(deltaTime);
        }
    }
}
