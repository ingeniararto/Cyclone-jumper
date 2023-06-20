using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyclone.Core;

namespace Common.Unity.Drawing
{

    public class SphereRenderer : BaseRenderer
    {

        public SphereRenderer(float size)
        {
            Size = size;
        }

        public SphereRenderer(float size, DRAW_ORIENTATION orientation)
        {
            Size = size;
            Orientation = DRAW_ORIENTATION.XY;
        }

        public float Size = 0.1f;

        #region DOUBLE
        public  void Load(IEnumerable<Vector3d> vertices)
        {
            foreach (var v in vertices)
            {
                m_vertices.Add(v.ToVector4());
            }
        }

        public  void Load(Vector3d vertex)
        {
            m_vertices.Add(vertex.ToVector4());
        }

        #endregion

        #region UNITY
        public  void Load(IEnumerable<Vector3> vertices)
        {
            foreach (var v in vertices)
            {
                m_vertices.Add(v);
            }
        }

        public  void Load(IEnumerable<Vector2> vertices)
        {
            foreach (var v in vertices)
            {
                m_vertices.Add(v);
            }
        }
        #endregion

        #region DRAW
        public override void Draw(Camera camera, Matrix4x4 localToWorld)
        {
            GL.PushMatrix();

            GL.LoadIdentity();
            GL.modelview = camera.worldToCameraMatrix * LocalToWorld;
            GL.LoadProjectionMatrix(camera.projectionMatrix);

            Material.SetPass(0);
            GL.Begin(GL.QUADS);
            GL.Color(Color);


            DrawSphere();

            GL.End();

            GL.PopMatrix();
        }
        private void DrawSphere()
        {
            int segments = 32;
            float radius = Size * 0.5f;

            for (int i = 0; i < m_vertices.Count; i++)
            {
                Vector3 center = m_vertices[i];

                for (int j = 0; j < segments; j++)
                {
                    float lat0 = Mathf.PI * (-0.5f + (float)(j - 1) / segments);
                    float z0 = Mathf.Sin(lat0) * radius;
                    float zr0 = Mathf.Cos(lat0) * radius;

                    float lat1 = Mathf.PI * (-0.5f + (float)j / segments);
                    float z1 = Mathf.Sin(lat1) * radius;
                    float zr1 = Mathf.Cos(lat1) * radius;

                    GL.Begin(GL.TRIANGLE_STRIP);
                    GL.Color(Color);

                    for (int iSeg = 0; iSeg <= segments; iSeg++)
                    {
                        float lng = 2 * Mathf.PI * (float)(iSeg - 1) / segments;
                        float x = Mathf.Cos(lng);
                        float y = Mathf.Sin(lng);
                        
                        GL.Vertex3(center.x + x * zr0, center.y + y * zr0, center.z + z0);
                        GL.Vertex3(center.x + x * zr1, center.y + y * zr1, center.z + z1);
                    }

                    GL.End();
                }
            }
        }

        #endregion
    }

}
