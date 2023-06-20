using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;
using Cyclone.Rigid;
using Cyclone.Rigid.Constraints;
using Cyclone.Rigid.Collisions;
using Cyclone.Rigid.Forces;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

namespace CycloneUnityTestScenes
{

    public class RigidSphere : MonoBehaviour
    {
        public double mass = 1;

        public double damping = 0.9;

        public RigidBody m_body;
        private double jumpImpulse = 800;
        private float moveForce = 500;
        private bool isJumped = false;
        private CollisionSphere shape;
        public Health hp;
        private Vector3d lastPos;
        public bool dead;


        void Start()
        {
            
            var pos = transform.position.ToVector3d();
            var scale = transform.localScale.y * 0.5;
            var rot = transform.rotation.ToQuaternion();
            lastPos = pos;
            dead = false;

            m_body = new RigidBody();
            m_body.Position = pos;
            m_body.Orientation = rot;
            m_body.LinearDamping = damping;
            m_body.AngularDamping = damping;
            m_body.SetMass(mass);
            m_body.SetAwake(true);
            m_body.SetCanSleep(true);

            shape = new CollisionSphere(scale);
            shape.Body = m_body;
            hp = GetComponent<Health>();

            RigidPhysicsEngine.Instance.Bodies.Add(m_body);
            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(shape);
        }

        private void Update()
        {
            if (shape.levelFinished)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            // Listen for keyboard events
            float horizontal = Input.GetAxis("Horizontal");

            // Calculate the force to apply based on the input
            // Vector3d force = new Vector3d(horizontal, 0, 0) * moveForce;
            Vector3d movement = new Vector3d(horizontal, 0, 0);
            movement.Normalize();
            Vector3d force = movement * moveForce * (hp.speedRate)*Time.deltaTime;
            Vector3d j_force = new Vector3d(0, 0, 0);
           
            
            //m_body.Velocity +=(new Vector3d(horizontal*moveForce*(hp.speedRate)*0.01, 0, 0)); // add upward impulse

            // Apply the force to the character's rigid body
            // m_body.AddForce(force);
            

            // Jump when space bar is pressed and character is on the ground
            if (shape.isCollide)
            {
                
                if (lastPos.y > m_body.Position.y)
                {
                    if (!hp.reduceHealth((float)(lastPos.y - m_body.Position.y)))
                    {
                        dead = true;
                    }
                    
                }

                lastPos = m_body.Position;
            }
            else
            {
                if (lastPos.y < m_body.Position.y)
                {
                    lastPos = m_body.Position;
                }
            }

            if (shape.isShot)
            {
                shape.isShot = false;
                if (!hp.shot(10f))
                {
                    dead = true;
                }
            }

            /*if (shape.isOnSpring)
            {
                Vector3d jump = new Vector3d(0, 1, 0); 
                j_force = jump * jumpImpulse;
                //force += j_force;
                //m_body.Velocity +=(new Vector3d(0, jumpImpulse, 0)); // add upward impulse
                shape.isCollide = false;
                // add spring force
                shape.isOnSpring = false;
            }*/
            if (Input.GetKeyDown(KeyCode.Space) && shape.isCollide)
            {
                
                // Apply an impulse in the upward direction to make the character jump
                Vector3d jump = new Vector3d(0, 1, 0); 
                j_force = jump * jumpImpulse;
                //force += j_force;
                //m_body.Velocity +=(new Vector3d(0, jumpImpulse, 0)); // add upward impulse
                shape.isCollide = false;
            }
            m_body.AddForce(j_force);
            
            m_body.AddForce(force);
            
            //RigidPhysicsEngine.Instance.RunPhysics(Time.deltaTime);
            // Manually reset the rotation around the Y-axis
            m_body.Orientation = new Cyclone.Core.Quaternion(0, 0, 0, 0);
            transform.position = m_body.Position.ToVector3();
            transform.rotation = m_body.Orientation.ToQuaternion();
        }
        

    }

}
