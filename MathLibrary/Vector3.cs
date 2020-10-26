﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    class Vector3
    {
        private float _x;
        private float _y;
        private float _z;

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            if (vector.Magnitude == 0)
                return new Vector3();

            return vector / vector.Magnitude;
        }

        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.X * scalar, lhs.Y * scalar, lhs.Z * scalar);
        }

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {

            return new Vector3(lhs.X / scalar, lhs.Y / scalar, lhs.Z / scalar);
        }
    }
}
