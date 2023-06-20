using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;

using PLANE = Cyclone.Rigid.Collisions.CollisionPlane;



namespace CycloneUnityTestScenes
{
    public class CollisionPlane : MonoBehaviour
    {
        public Vector3d direction;
        private PLANE m_plane;
        public double position=0;

        void Start()
        {
         
            m_plane = new PLANE(direction, position);
            RigidPhysicsEngine.Instance.Collisions.Planes.Add(m_plane);
        }

    }
}
