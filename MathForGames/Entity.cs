using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Entity
    {
        protected char _icon;
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected Matrix3 _transform = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_transform.m11, _transform.m21);
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_transform.m13, _transform.m23);
            }
            set
            {
                _transform.m13 = value.X;
                _transform.m23 = value.Y;
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

        public void Translate(Vector2 position)
        {
            _translation.m13 = position.X;
            _translation.m23 = position.Y;
        }

        public void Rotate(float radians)
        {
            _rotation.m11 = (float)(Math.Cos(radians));
            _rotation.m12 = (float)(Math.Sin(radians));
            _rotation.m21 = (float)(-Math.Sin(radians));
            _rotation.m22 = (float)(Math.Cos(radians));
        }

        public void Scale(float x, float y)
        {
            _scale.m12 = x;
            _scale.m21 = y;
        }

        private void UpdateTransform()
        {
            _transform += _translation * _rotation * _scale;
        }
        
        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Green)
        {
            _rayColor = Color.GOLD;
            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green) : this(x,y,icon,color)
        {
            _rayColor = rayColor;
        }

       public virtual void Start()
       {
            Started = true;
       }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            //Increase position by the current velocity
            Position += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            //Draws the actor and a line indicating it
            Raylib.DrawText(_icon.ToString(), (int)_position.X * 32, (int)_position.Y * 32, 18, _rayColor);
            Raylib.DrawLine(
                    (int)(Position.X * 32), 
                    (int)(Position.Y * 32), 
                    (int)((Position.X + Forward.X) * 32), 
                    (int)((Position.Y + Forward.Y) * 32), 
                    Color.WHITE
                );

            Console.ForegroundColor = _color;

            //Only draws the actor on the console if it is within the bounds of the window
            if(Position.X >= 0 && Position.X < Console.WindowWidth &&Position.Y >= 0 && Position.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)_position.X, (int)_position.Y);
                Console.Write(_icon);
            }

            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
