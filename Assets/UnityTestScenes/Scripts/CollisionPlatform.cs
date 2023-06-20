using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;

using PLATFORM = Cyclone.Rigid.Collisions.CollisionBox;

namespace CycloneUnityTestScenes
{
    public class CollisionPlatform : MonoBehaviour
    {

        private PLATFORM m_plane;

        void Start()
        {
            double y = transform.localScale.y/2;

            m_plane = new PLATFORM(y);

            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(m_plane);
        }

    }
}