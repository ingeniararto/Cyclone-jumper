using System;
using System.Collections.Generic;

using Cyclone.Core;
using Cyclone.Rigid;
using Unity.VisualScripting;

namespace Cyclone.Rigid.Collisions
{
    ///<summary>
    /// Represents a rigid body that can be treated as a sphere
    /// for collision detection.
    ///</summary>
    
    public class CollisionBullet : CollisionPrimitive
    {
        public double Radius;
        public bool IsCollide = false;

        public CollisionBullet(double radius)
        {
            Radius = radius;
        }
    }
}