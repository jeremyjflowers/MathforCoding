using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Sprite _sprite;
        private Sprite _enemyBullet;
        private Actor _target;
        private float radians;

        public Actor Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Blue) : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Blue) : base(x, y, icon, color)
        {
            _sprite = new Sprite("Images/enemyBlack2.png");
        }

        public void FireLaser()
        {
            _enemyBullet = new Sprite("Images/laserRed02.png");


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxAngle"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public bool CheckTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;

            Vector2 direction = Target.LocalPosition - LocalPosition;
            float distance = direction.Magnitude;
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));
            if (angle <= maxAngle && distance <= maxDistance)
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            if(CheckTargetInSight(5.5f, 5.5f))
            {
                FireLaser();
            }

            SetRotate((radians += deltaTime) * 32);

            base.Update(deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
