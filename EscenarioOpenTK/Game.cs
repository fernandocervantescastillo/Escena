using EscenarioOpenTK.objects;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK
{
    class Game : GameWindow
    {
        public Game()
            : base(512, 512, new GraphicsMode(32, 24, 0, 4))
        {

        }

        Matrix4[] mviewdata;
        Escenario escenario;
        float t;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            mviewdata = new Matrix4[]{
                Matrix4.Identity
            };

            escenario = new Escenario();

            Title = "Hello OpenTK!";
            GL.ClearColor(Color.CornflowerBlue);
            GL.PointSize(5f);
            t = 0;

        }




        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Viewport(0, 0, Width, Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            t += (float)e.Time;
            mviewdata[0] = Matrix4.CreateRotationY(0.55f * t) * Matrix4.CreateRotationX(0.15f) * Matrix4.CreateTranslation(0.0f, 0.0f, -4.0f) * Matrix4.CreatePerspectiveFieldOfView(1.3f, ClientSize.Width / (float)ClientSize.Height, 1.0f, 40.0f);
            escenario.draw(mviewdata);


            GL.Flush();
            SwapBuffers();
        }

    }
}
