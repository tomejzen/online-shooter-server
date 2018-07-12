﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace GameServer.Physics
{
    public class Physic
    {
        public static Vector2 GetLeftParallelVectorToIntersectionNormal(Vector2 movementVector, float intersectionDistance, Vector2 intersectionNormal)
        {
            float movementVectorLength = movementVector.Length();
            var realMovementDirectionVector = Vector2.Normalize(movementVector) * intersectionDistance;

            var leftMovementDirectionVector = movementVector - realMovementDirectionVector;
            return GetParallelVectorToNormal(leftMovementDirectionVector, intersectionNormal);
        }

        public static double GetAngleBetweenVectors(Vector2 a, Vector2 b)
        {
            var sin = b.X * a.Y - a.X * b.Y;
            var cos = b.X * a.X + b.Y * a.Y;

            return Math.Atan2(sin, cos);
        }

        public static Vector2 GetParallelVectorToNormal(Vector2 vector, Vector2 normal)
        {
            return ProjectVector(vector, RotateVector(normal, (float)(Math.PI / 2)));
        }

        public static Vector2 ProjectVector(Vector2 vector, Vector2 projectionVector)
        {
            var m = (projectionVector.Y) / (projectionVector.X);

            var x = (m * vector.Y + vector.X) / (m * m + 1);
            var y = (m * m * vector.Y + m * vector.X) / (m * m + 1);

            return new Vector2(x, y);
        }

        public static Vector2 RotateVector(Vector2 v, float angle)
        {
            var ca = (float)Math.Cos(angle);
            var sa = (float)Math.Sin(angle);
            return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }
}
