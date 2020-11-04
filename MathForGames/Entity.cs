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
        protected Matrix3 _globalTransform;
        protected Matrix3 _localTransform;
        protected Matrix3 _transform = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Entity _parent;
        protected Entity[] _children = new Entity[0];
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_localTransform.m11, _localTransform.m21);
            }
        }

        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
        }

        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
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
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Green) : this(x,y,icon,color)
        {
            _transform = new Matrix3();
            _rayColor = rayColor;
        }

        public void AddChild(Entity child)
        {
            Entity[] tempArray = new Entity[_children.Length + 1];

            for(int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }

        public bool RemoveChild(Entity child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Entity[] tempArray = new Entity[_children.Length - 1];
            int j = 0;

            for(int i = 0; i < _children.Length; i++)
            {
                if(child != _children[i])
                {
                    tempArray[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArray;
            child._parent = null;
            return childRemoved;
        }

        public void Translate(Vector2 position)
        {
            _translation.m13 = position.X;
            _translation.m23 = position.Y;
        }

        public void Rotate(float radians)
        {
            _rotation.m11 = (float)Math.Cos(radians);
            _rotation.m21 = -(float)Math.Sin(radians);
            _rotation.m12 = (float)Math.Sin(radians);
            _rotation.m22 = (float)Math.Cos(radians);
        }

        public void Scale(float x, float y)
        {
            _scale.m11 = x;
            _scale.m22 = y;
        }

        private void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;
        }

        public virtual void Start()
       {
            Started = true;
       }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            //Increase position by the current velocity
            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            //Draws the actor and a line indicating it
            Raylib.DrawText(_icon.ToString(), (int)_position.X * 32, (int)_position.Y * 32, 18, _rayColor);
            Raylib.DrawLine(
                    (int)(LocalPosition.X * 32), 
                    (int)(LocalPosition.Y * 32), 
                    (int)((LocalPosition.X + Forward.X) * 32), 
                    (int)((LocalPosition.Y + Forward.Y) * 32), 
                    Color.WHITE
                );

            Console.ForegroundColor = _color;

            //Only draws the actor on the console if it is within the bounds of the window
            if(LocalPosition.X >= 0 && LocalPosition.X < Console.WindowWidth && LocalPosition.Y >= 0 && LocalPosition.Y < Console.WindowHeight)
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
