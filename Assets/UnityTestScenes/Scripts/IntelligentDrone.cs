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

    public class IntelligentDrone : MonoBehaviour
    {
        public double mass = 0;

        public double damping = 0.9;

        private RigidBody m_body;
        private float moveForce =  3;
        private bool isJumped = false;
        private CollisionDrone shape;
        private Vector3d initialPosition;
        public float movementDistance;
        public GameObject bullet;
        public float shootInterval = 2f;
        public float timer = 3f;
        public GameObject player;
        public float speed;

        void Start()
        {
            
            var pos = transform.position.ToVector3d();
            var scale = transform.localScale.y * 0.5;
            var rot = transform.rotation.ToQuaternion();
            initialPosition = pos;
            

            m_body = new RigidBody();
            m_body.Position = pos;
            m_body.Orientation = rot;
            m_body.LinearDamping = damping;
            m_body.AngularDamping = damping;
            m_body.SetMass(mass);
            m_body.SetAwake(true);
            m_body.SetCanSleep(true);

            shape = new CollisionDrone(scale);
            shape.Body = m_body;

            RigidPhysicsEngine.Instance.Bodies.Add(m_body);
            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(shape);
        }

        private void Update()
        {
            Vector3d target_position = player.GetComponent<RigidSphere>().m_body.Position;
            
            Vector3d difference = (target_position - m_body.Position);
            Vector3d desiredDirection = difference.Normalized;
            if (difference.Magnitude < 5)
            {
                m_body.Velocity = desiredDirection * 0;
            }
            else
            {
                m_body.Velocity = desiredDirection * speed;

            }


            m_body.Position = new Vector3d(m_body.Position.x, m_body.Position.y, 0);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Shoot(desiredDirection);
                timer = shootInterval;
            }
            
            
            //RigidPhysicsEngine.Instance.RunPhysics(Time.deltaTime);
            // Manually reset the rotation around the Y-axis
            
            m_body.Orientation = new Cyclone.Core.Quaternion(0, 0, 0, 0);
            transform.position = m_body.Position.ToVector3();
            transform.rotation = m_body.Orientation.ToQuaternion();
  
        }

        private void Shoot(Vector3d desiredDirection)
        {
            Debug.Log("created");
            GameObject bulletInstance = Instantiate(bullet,  m_body.Position.ToVector3(), m_body.Orientation.ToQuaternion());
            bulletInstance.AddComponent<Bullet>();
            bulletInstance.GetComponent<Bullet>().direction = desiredDirection ;
        }

    }


}
