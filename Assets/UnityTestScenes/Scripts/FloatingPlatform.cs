using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;
using Cyclone.Rigid;
using Cyclone.Rigid.Constraints;
using Cyclone.Rigid.Collisions;

namespace CycloneUnityTestScenes
{

    public class FloatingPlatform : MonoBehaviour
    {
        public double mass = 1;

        public double damping = 0;

        public RigidBody m_body;
        private double initial_y, initial_x;
        public bool isSnow = false;

        
        
        void Start()
        {
            var pos = transform.position.ToVector3d();
            var scale = transform.localScale.ToVector3d() * 0.5;
            var rot = transform.rotation.ToQuaternion();

            m_body = new RigidBody();
            m_body.Position = pos;
            m_body.Orientation = rot;
            m_body.LinearDamping = damping;
            m_body.AngularDamping = damping;
            m_body.SetMass(mass);
            m_body.SetAwake(true);
            m_body.SetCanSleep(true);
            
            initial_y = pos.y;
            initial_x = pos.x;

            var shape = new CollisionBox(scale);
            shape.isSnow = isSnow;
            shape.Body = m_body;
            
            RigidPhysicsEngine.Instance.Bodies.Add(m_body);
            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(shape);
            
            
            
        }

        private void Update()
        {
            
           
           
            // Manually reset the rotation around the Y-axis
            m_body.Orientation = new Cyclone.Core.Quaternion(0,0,180,0);
            m_body.Velocity = new Vector3d(0, 0, 0);
            // Lock the position on the Y-axis
            m_body.Position = new Vector3d(initial_x, initial_y, 0);

            transform.position = m_body.Position.ToVector3();
            transform.rotation = m_body.Orientation.ToQuaternion();
            
        }

    }

}
