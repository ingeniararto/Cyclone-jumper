using System;
using System.Collections.Generic;

using Cyclone.Core;

namespace Cyclone.Rigid.Collisions
{
    public class CollisionBar: CollisionPrimitive
    {
        public Vector3d HalfSize;

        public bool isSnow;

        public CollisionBar(double halfSize)
        {
            HalfSize = new Vector3d(halfSize);
        }

        public CollisionBar(Vector3d halfSize)
        {
            HalfSize = halfSize;
        }
    }
    
}