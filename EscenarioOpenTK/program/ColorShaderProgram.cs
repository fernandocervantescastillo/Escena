using EscenarioOpenTK.util;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.program
{
    class ColorShaderProgram
    {
        private String V_POSITION = "vPosition";
        private String V_COLOR = "vColor";
        private String MODEL_VIEW = "modelview";

        public int vPosition;
        public int vColor;
        public int modelView;

        public int program;



        public ColorShaderProgram(String vertexShaderResource, String fragmentShaderResource)
        {
            program = ShaderHelper.buildProgram(vertexShaderResource, fragmentShaderResource);

            vPosition = GL.GetAttribLocation(program, V_POSITION);
            vColor = GL.GetAttribLocation(program, V_COLOR);
            modelView = GL.GetUniformLocation(program, MODEL_VIEW);
        }


        public void enableShader()
        {
            GL.EnableVertexAttribArray(vPosition);
            GL.EnableVertexAttribArray(vColor);
        }

        public void disableShader()
        {
            GL.DisableVertexAttribArray(vPosition);
            GL.DisableVertexAttribArray(vColor);
        }

        public void useProgram()
        {
            GL.UseProgram(program);
        }

    }
}
