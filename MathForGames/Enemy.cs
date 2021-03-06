﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Sprite _sprite;
        private Actor _target;

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
            _collisionRadius = 1;
        }

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

        public override void Update(float deltaTime)
        {
            if(CheckTargetInSight(15.5f, 15.5f))
            {
                Laser laser = new Laser(4, 8, Color.RED, '&', ConsoleColor.Red);
            }

            SetRotate(radians += deltaTime);

            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}
