using System;
using System.Collections.Generic;

using Cyclone.Core;
using Cyclone.Rigid;

namespace Cyclone.Rigid.Collisions
{
    ///<summary>
    /// Represents a rigid body that can be treated as a sphere
    /// for collision detection.
    ///</summary>
    public class CollisionSphere : CollisionPrimitive
    {
        public double Radius;
        public bool isCollide;
        public bool isShot;
        public bool isOnSpring;
        public bool levelFinished;

        public CollisionSphere(double radius)
        {
            levelFinished = false;
            isCollide = false;
            Radius = radius;
            isShot = false;
            isOnSpring = false;
        }
    }
}
