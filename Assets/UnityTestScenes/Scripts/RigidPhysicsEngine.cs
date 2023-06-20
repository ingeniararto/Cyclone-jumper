using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Rigid;
using Cyclone.Rigid.Forces;

namespace CycloneUnityTestScenes
{

    public class RigidPhysicsEngine : MonoBehaviour
    {
        public int iterations = 0;

        public int maxContacts = 10;

        public double epsilon = 0.01;
        

        public static RigidBodyEngine Instance { get; private set; }

        private void Awake()
        {
            Instance = new RigidBodyEngine(maxContacts);
            Instance.Resolver.PositionIterations = iterations;
            Instance.Resolver.VelocityIterations = iterations;
            Instance.Resolver.PositionEpsilon = epsilon;
            Instance.Resolver.VelocityEpsilon = epsilon;
            Instance.Collisions.Restitution = 0;
            Instance.Collisions.Friction = 0.3;

            Instance.ForceAreas.Add(new RigidGravityForce(-20));
        }

        private void FixedUpdate()
        {
            double dt = Time.fixedDeltaTime;

            Instance.StartFrame();
            Instance.RunPhysics(dt);
        }
    }

}
