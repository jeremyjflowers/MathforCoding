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
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Entity _parent;
        protected Entity[] _children = new Entity[0];
        protected float _collisionRadius;
        protected float radians;
        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2(_globalTransform.m11, _globalTransform.m21);
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

        public void SetTranslate(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotate(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        public void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;
        }

        public void UpdateGlobalTransform()
        {
            if (_parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }
        }

        /// <summary>
        /// Checks to see if this entity overlaps another
        /// </summary>
        /// <param name="other">The entity that this entity is checking collision against</param>
        /// <returns></returns>
        public bool CheckCollision(Entity other)
        {

            return false;
        }

        /// <summary>
        /// Called whenever a collision occurs between this entity and another. Use this to define game logic for this entity's collision
        /// </summary>
        /// <param name="other"></param>
        public virtual void OnCollision(Entity other)
        {
           
        }

        public virtual void Start()
       {
            Started = true;
       }

        public virtual void Update(float deltaTime)
        {
            UpdateTransform();
            UpdateGlobalTransform();

            //Increase position by the current velocity
            LocalPosition += _velocity * deltaTime;

            SetRotate((radians += deltaTime) * 100);
        }

        public virtual void Draw()
        {
            //Draws the actor and a line indicating it
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 18, _rayColor);
            Raylib.DrawLine(
                    (int)(WorldPosition.X * 32), 
                    (int)(WorldPosition.Y * 32), 
                    (int)((WorldPosition.X + Forward.X) * 32), 
                    (int)((WorldPosition.Y + Forward.Y) * 32), 
                    Color.WHITE
                );

            Console.ForegroundColor = _color;

            //Only draws the actor on the console if it is within the bounds of the window
            if(WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
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
