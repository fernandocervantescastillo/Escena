using EscenarioOpenTK.program;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.objects
{
    class Mesa : Objeto
    {
        Matrix4[] matrix;
        Cubo pata1;
        Cubo pata2;
        Cubo pata3;
        Cubo pata4;
        Cubo mesa;
        float ex;
        float ey;
        float ez;
        float baseX, baseY, baseZ;
        ColorShaderProgram colorShaderProgram;
        public Mesa(float baseX, float baseY, float baseZ)
        {
            this.baseX = baseX;
            this.baseY = baseY;
            this.baseZ = baseZ;

            ex = baseX * 0.1f;
            ey = baseY * 0.1f;
            ez = baseZ * 0.1f;

            pata1 = new Cubo(ex, baseY - ey, ez);
            pata2 = new Cubo(ex, baseY - ey, ez);
            pata3 = new Cubo(ex, baseY - ey, ez);
            pata4 = new Cubo(ex, baseY - ey, ez);

            mesa = new Cubo(baseX, ey, baseZ);

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
            GL.UniformMatrix4(colorShaderProgram.modelView, false, ref matriz[0]);
            pata1.bindData(colorShaderProgram);
            pata1.draw(null);

            matrix[0] = Matrix4.CreateTranslation(baseX - ex, 0.0f, 0.0f) * matriz[0];
            GL.UniformMatrix4(colorShaderProgram.modelView, false, ref matrix[0]);
            pata2.bindData(colorShaderProgram);
            pata2.draw(null);

            matrix[0] = Matrix4.CreateTranslation(0.0f, 0.0f, baseZ - ez) * matriz[0];
            GL.UniformMatrix4(colorShaderProgram.modelView, false, ref matrix[0]);
            pata3.bindData(colorShaderProgram);
            pata3.draw(null);

            matrix[0] = Matrix4.CreateTranslation(baseX - ex, 0.0f, baseZ - ez) * matriz[0];
            GL.UniformMatrix4(colorShaderProgram.modelView, false, ref matrix[0]);
            pata4.bindData(colorShaderProgram);
            pata4.draw(null);

            matrix[0] = Matrix4.CreateTranslation(0, baseY - ey, 0) * matriz[0];
            GL.UniformMatrix4(colorShaderProgram.modelView, false, ref matrix[0]);
            mesa.bindData(colorShaderProgram);
            mesa.draw(null);
        }
    }
}
