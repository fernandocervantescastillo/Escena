using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.data
{
    class IndexArray
    {
        private int indexArrayPosition;
        public IndexArray(int[] indexData)
        {

            GL.GenBuffers(1, out indexArrayPosition);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexArrayPosition);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indexData.Length * sizeof(int)), indexData, BufferUsageHint.StaticDraw);
        }

        public int getIndexArrayPosition()
        {
            return indexArrayPosition;
        }
    }
}
