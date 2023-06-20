using System;
using System.Collections.Generic;

using Cyclone.Core;

namespace Cyclone.Rigid.Collisions
{
    /// <summary>
    /// Represents a rigid body that can be treated as an aligned bounding
    /// box for collision detection.
    /// </summary>
    public class CollisionSpring : CollisionPrimitive
    {
        /// <summary>
        /// Holds the half-sizes of the box along each of its local axes.
        /// </summary>
        public Vector3d HalfSize;

        public bool isApplied = false;

        public CollisionSpring(double halfSize)
        {
            HalfSize = new Vector3d(halfSize);
        }

        public CollisionSpring(Vector3d halfSize)
        {
            HalfSize = halfSize;
        }
    }
}