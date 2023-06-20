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

    public class RigidBox : MonoBehaviour
    {
        public double mass = 1;

        public double damping = 0.9;

        private RigidBody m_body;
        private double jumpImpulse = 10;
        private float moveForce = 10;
        private bool isJumped = false;

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

            var shape = new CollisionBox(scale);
            shape.Body = m_body;
            
            RigidPhysicsEngine.Instance.Bodies.Add(m_body);
            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(shape);
        }

        private void Update()
        {
            
            // Listen for keyboard events
            float horizontal = Input.GetAxisRaw("Horizontal");

            // Calculate the force to apply based on the input
            // Vector3d force = new Vector3d(horizontal, 0, 0) * moveForce;
            m_body.Velocity +=(new Vector3d(horizontal*moveForce*0.001, 0, 0)); // add upward impulse

            // Apply the force to the character's rigid body
            // m_body.AddForce(force);


            // Jump when space bar is pressed and character is on the ground
            if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
            {
                // Apply an impulse in the upward direction to make the character jump
                m_body.Velocity +=(new Vector3d(0, jumpImpulse, 0)); // add upward impulse
                isJumped = true;
            }

            if (m_body.Velocity.y <= 0.1 && m_body.Velocity.y>=-0.1)
            {
                isJumped = false;
            }
            // Manually reset the rotation around the Y-axis
            m_body.Orientation = new Cyclone.Core.Quaternion(0, 0, 0, 0);
            transform.position = m_body.Position.ToVector3();
            transform.rotation = m_body.Orientation.ToQuaternion();
            
        }

    }

}
