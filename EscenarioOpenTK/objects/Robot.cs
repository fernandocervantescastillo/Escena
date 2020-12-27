using EscenarioOpenTK.program;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.objects
{
    class Robot : Objeto
    {
        Matrix4[] matrix;
        Cubo pie1, pie2, pierna1, pierna2, brazo1, brazo2, torso, cabeza;
        float ex;
        float ey;
        float ez;
        float baseX, baseY, baseZ;
        ColorShaderProgram colorShaderProgram;
        public Robot(float baseX, float baseY, float baseZ)
        {
            this.baseX = baseX;
            this.baseY = baseY;
            this.baseZ = baseZ;

            ex = baseX * 0.1f;
            ey = baseY * 0.1f;
            ez = baseZ * 0.1f;


            pie1 = new Cubo(ex, ey, ez);


            matrix = new Matrix4[]{
                Matrix4.Identity
            };
        }

        public void bindData(ColorShaderProgram colorShaderProgram)
        {
            this.colorShaderProgram = colorShaderProgram;
        }

        public void draw(Matrix4[] matriz)
        {
            
        }
    }
}
