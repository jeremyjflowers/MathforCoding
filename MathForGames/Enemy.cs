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
        private Sprite _spirte;

        public Entity Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow) : base(x, y, icon, color)
        {
            _spirte = new Sprite("Images/enemy.png");
        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White) : base(x, y, rayColor, icon, color)
        {
            _spirte = new Sprite("Images/enemy.png");
            _alertColor = Color.RED;
        }

        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;
            //Find the vector representing the distance between the entity and its target
            Vector2 direction = Target.WorldPosition - LocalPosition;
            //Get the magnitude of the distance vector
            float distance = direction.Magnitude;
            //Use the inverse cosine to find the angle of the dot product in radians
            float angle = (float)Math.Acos((Vector2.DotProduct(Forward, direction.Normalized)));

            if (angle <= maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        public override void Update(float deltaTime)
        {
            if(CheckTargetInSight(1.5f, 0))
            {
                _rayColor = Color.RED;
            }
            else
            {
                _rayColor = Color.GREEN;
            }

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _spirte.Draw(_transform);
            base.Draw();
        }
    }
}
