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
        protected Matrix3 _transform;
        protected Matrix3 _rotation;
        protected Matrix3 _translation;
        protected Matrix3 _scale;
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_transform.m11, _transform.m21);
            }
            set
            {
                _transform.m11 = value.X; 
                _transform.m21 = value.Y;
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

        public Vector2 Rotation
        {
            get
            {
                return new Vector2(_rotation.m12 , _rotation.m22);
            }
            set
            {
                _rotation.m12 = value.X;
                _rotation.m22 = value.Y;
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
            _transform = new Matrix3();
            _rotation = new Matrix3();
            _position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            Forward = new Vector2(1, 0);
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green) : this(x,y,icon,color)
        {
            _transform = new Matrix3();
            _rotation = new Matrix3();
            _rayColor = rayColor;
        }

        private void UpdateFacing()
        {
            if (_velocity.Magnitude <= 0)
                return;

            Forward = Velocity.Normalized;
        }

        private void UpdateRotation()
        {

        }

       public virtual void Start()
       {
            Started = true;
       }

        public virtual void Update(float deltaTime)
        {
            //Before the actor is moved, update the direction it is facing
            UpdateFacing();

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
