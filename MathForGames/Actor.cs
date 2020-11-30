﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon;
        private Vector2 _velocity = new Vector2();
        private Vector2 acceleration = new Vector2();
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        protected Actor[] _children = new Actor[0];
        protected float _collisionRadius;
        protected float _maxSpeed;

        public bool Started { get; private set; }

        public void AddChild(Actor child)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;
            _children = tempArray;
            child._parent = this;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;

            if (child == null)
                return false;

            Actor[] tempArray = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
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


        public Vector2 Forward
        {
            get
            {
                return new Vector2(_globalTransform.m11, _globalTransform.m12);
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

        public Vector2 Acceleration
        {
            get
            {
                return acceleration;
            }
            set
            {
                acceleration = value;
            }
        }

        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                _maxSpeed = value;
            }
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

        public void UpdateGlobalTransform()
        {
            _localTransform = _translation * _rotation * _scale;

            if (_parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }
        }

        public bool CheckCollision(Actor other)
        {
            float distance = (other.WorldPosition - WorldPosition).Magnitude;
            return distance <= other._collisionRadius + _collisionRadius;
        }

        public virtual void OnCollision(Actor other)
        {
            if(CheckCollision(other) != false)
            {
               
            }
        }

        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow)
        {
            _rayColor = Color.BROWN;
            _icon = icon;
            _color = color;
            _localTransform = new Matrix3();
        }

        public Actor(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.Yellow) : this(x, y, icon, color)
        {
            _rayColor = rayColor;
            _localTransform = new Matrix3();
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            UpdateGlobalTransform();

            Velocity += Acceleration;
            if(Velocity.Magnitude > MaxSpeed)
            {
                Velocity = Velocity.Normalized * MaxSpeed;
            }

            LocalPosition += _velocity * deltaTime;
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 18, _rayColor);
            Raylib.DrawLine(
                    (int)(WorldPosition.X * 32),
                    (int)(WorldPosition.Y * 32),
                    (int)((WorldPosition.X + Forward.X) * 32),
                    (int)((WorldPosition.Y + Forward.Y) * 32),
                    Color.WHITE
                );

            Console.ForegroundColor = _color;

            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
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