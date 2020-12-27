using EscenarioOpenTK.program;
using EscenarioOpenTK.util;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.objects
{
    class Escenario
    {

        Matrix4[] mviewdata;/// Array of our modelview matrices

        ColorShaderProgram colorShaderProgram;

        Mesa mesa;
        Silla silla;
        Robot robot;

        List<Objeto> lista;

        public Escenario()
        {
            lista = new List<Objeto>();


            String vertexCode = TextResourceReader.readTextFileFromResource("shaders/vs.glsl");
            String fragmentCode = TextResourceReader.readTextFileFromResource("shaders/fs.glsl");

            colorShaderProgram = new ColorShaderProgram(vertexCode, fragmentCode);

            mviewdata = new Matrix4[]{
                Matrix4.Identity
            };


            mesa = new Mesa(1f, 0.75f, 1f);
            silla = new Silla(0.5f, 1f, 0.5f);
            robot = new Robot(0.5f, 1f, 0.5f);
            lista.Add(mesa);
            lista.Add(silla);
            lista.Add(robot);

        }


        public void draw(Matrix4[] matriz)
        {


            colorShaderProgram.enableShader();
            colorShaderProgram.useProgram();


            mviewdata[0] = Matrix4.CreateTranslation(-0.2f, 0.0f, 0.4f) * matriz[0];
            mesa.bindData(colorShaderProgram);
            mesa.draw(mviewdata);

            silla.bindData(colorShaderProgram);
            silla.draw(matriz);
            /*
            robot.bindData(colorShaderProgram);
            robot.draw(matriz);
            */
            colorShaderProgram.disableShader();
        }


    }
}
