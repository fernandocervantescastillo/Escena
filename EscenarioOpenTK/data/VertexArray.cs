using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.data
{
    class VertexArray
    {
        private int vertexArrayPosition;


        public VertexArray()
        {
            GL.GenBuffers(1, out vertexArrayPosition);
        }

        public void setVertexAttribPointer(Vector3[] vertexData, int attributeLocation)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexArrayPosition);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertexData.Length * Vector3.SizeInBytes), vertexData, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attributeLocation, 3, VertexAttribPointerType.Float, true, 0, 0);
        }
    }
}
