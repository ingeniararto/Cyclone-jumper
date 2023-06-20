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
    public class CollisionDrone : CollisionPrimitive
    {
        public double Radius;
        public bool isCollide;
        public bool isShot;

        public CollisionDrone(double radius)
        {
            isCollide = false;
            Radius = radius;
            isShot = false;
        }
    }
}