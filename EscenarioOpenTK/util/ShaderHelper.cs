using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscenarioOpenTK.util
{
    class ShaderHelper
    {
        const String TAG = "ShaderHelper";
        public static int compileVertexShader(String shaderCode)
        {
            return compileShader(ShaderType.VertexShader, shaderCode);
        }

        public static int compileFragmentShader(String shaderCode)
        {
            return compileShader(ShaderType.FragmentShader, shaderCode);
        }

        private static int compileShader(ShaderType type, String shaderCode)
        {
            //Crea un nuevo shader object
            int shaderObjectId = GL.CreateShader(type);

            if (shaderObjectId == 0)
            {
                if (LoggerConfig.ON)
                {
                    Console.WriteLine(TAG + ": No se pudo crear un nuevo shader");
                }
                return 0;
            }

            //Agregar al shader el codigo
            GL.ShaderSource(shaderObjectId, shaderCode);

            //Compilar el shader
            GL.CompileShader(shaderObjectId);

            //Obtiene el status de la compilacion
            int compileStatus;
            GL.GetShader(shaderObjectId, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, out compileStatus);

            if (LoggerConfig.ON)
            {
                Console.WriteLine(TAG + ": " + "\n" + shaderCode + "\n" + GL.GetShaderInfoLog(shaderObjectId));
            }

            //Verificamos si compilo bien
            if (compileStatus == 0)
            {
                //Si no compilo bien, borramos el shader
                GL.DeleteShader(shaderObjectId);

                if (LoggerConfig.ON)
                {
                    Console.WriteLine("La compilacion del shader fallo");
                }

                return 0;
            }

            return shaderObjectId;
        }

        public static int linkProgram(int vertexShaderId, int fragmentShaderId)
        {
            int programObjectId = GL.CreateProgram();

            if (programObjectId == 0)
            {
                if (LoggerConfig.ON)
                {
                    Console.WriteLine(TAG + ": No se pudo crear un nuevo programa");
                }
                return 0;
            }

            //Attach el fragment y el vertex al programa
            GL.AttachShader(programObjectId, vertexShaderId);
            GL.AttachShader(programObjectId, fragmentShaderId);

            //Link los dos shader juntos en un programa
            GL.LinkProgram(programObjectId);

            //Obtenemos el estado del link
            int linkStatus;
            GL.GetProgram(programObjectId, ProgramParameter.LinkStatus, out linkStatus);

            if (LoggerConfig.ON)
            {
                Console.WriteLine(TAG + ": Resultado del link program:\n" + GL.GetProgramInfoLog(programObjectId));
            }

            //Verificamos el estado del link
            if (linkStatus == 0)
            {
                //Si fallo, borramos el objeto programa
                GL.DeleteProgram(programObjectId);

                if (LoggerConfig.ON)
                {
                    Console.WriteLine(TAG + ": Fallo el link del programa");
                }

                return 0;

            }

            return programObjectId;
        }

        public static bool validateProgram(int programObjectId)
        {
            GL.ValidateProgram(programObjectId);
            int validateStatus;
            GL.GetProgram(programObjectId, ProgramParameter.ValidateStatus, out validateStatus);
            Console.WriteLine(TAG + ": Resultados de la validacion del programa: " + validateStatus);
            Console.WriteLine("Log: " + GL.GetProgramInfoLog(programObjectId));
            return validateStatus != 0;
        }

        public static int buildProgram(String vertexShaderSource, String fragmentShaderSource)
        {
            int program;
            int vertexShader = compileVertexShader(vertexShaderSource);
            int fragmenShader = compileFragmentShader(fragmentShaderSource);

            program = linkProgram(vertexShader, fragmenShader);

            if (LoggerConfig.ON)
            {
                validateProgram(program);
            }

            return program;
        }

    }
}
