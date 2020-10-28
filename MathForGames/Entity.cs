﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Entity
    {
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected Matrix3 _transform;
        private Vector2 _facing;
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get { return new Vector2(_transform.m11, _transform.m21); }
            set { _transform.m11 = value.X; _transform.m21 = value.Y; }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }
        
        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
        {
            _rayColor = Color.GOLD;
            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green) : this(x,y,icon,color)
        {
            _rayColor = rayColor;
        }

        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            _facing = Velocity.Normalized;
        }

       public virtual void Start()
       {
            Started = true;
       }

        public virtual void Update(float deltaTime)
        {
            UpdateFacing();
            _position += _velocity * deltaTime;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight-1);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)_position.X * 32, (int)_position.Y * 32, 18, _rayColor);
            Raylib.DrawLine(
                    (int)(Position.X * 32), 
                    (int)(Position.Y * 32), 
                    (int)((Position.X + Forward.X) * 32), 
                    (int)((Position.Y + Forward.Y) * 32), 
                    Color.WHITE
                );

            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
