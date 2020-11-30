﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Tank : Actor
    {
        private float _speed;
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
            _sprite = new Sprite("Images/tankBody_darkLarge_outline.png");
        }

        public override void Update(float deltaTime)
        {
            int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
               + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Acceleration = new Vector2(xDirection, yDirection);
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
