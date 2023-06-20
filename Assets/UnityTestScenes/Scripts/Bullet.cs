using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;
using Cyclone.Rigid;
using Cyclone.Rigid.Constraints;
using Cyclone.Rigid.Collisions;

namespace CycloneUnityTestScenes
{

    public class Bullet : MonoBehaviour
    {
        public double mass = 1;

        public double damping = 0.9;

        private RigidBody m_body;
        private float moveForce =  10;
        private CollisionBullet shape;
        public Vector3d direction;
        private double start = -7.45;
        private double end = 8;


        void Start()
        {
            
            var pos = transform.position.ToVector3d();
            var scale = transform.localScale.y * 0.5;
            var rot = transform.rotation.ToQuaternion();


            m_body = new RigidBody();
            m_body.Position = pos;
            m_body.Orientation = rot;
            m_body.LinearDamping = damping;
            m_body.AngularDamping = damping;
            m_body.SetMass(mass);
            m_body.SetAwake(true);
            m_body.SetCanSleep(true);

            shape = new CollisionBullet(scale);
            shape.Body = m_body;

            RigidPhysicsEngine.Instance.Bodies.Add(m_body);
            RigidPhysicsEngine.Instance.Collisions.Primatives.Add(shape);
        }

        private void Update()
        {

            m_body.Velocity = direction * moveForce;

            if (m_body.Position.x > end || m_body.Position.x<start || shape.IsCollide)
            {
                Destroy(gameObject);
            }
            m_body.Position = new Vector3d(m_body.Position.x,m_body.Position.y, 0);
            m_body.Orientation = new Cyclone.Core.Quaternion(0, 0, 0, 0);
            transform.position = m_body.Position.ToVector3();
            transform.rotation = m_body.Orientation.ToQuaternion();
        }
        

    }
    

}
