using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace AuTO
{
    public static class PyChallonge
    {
        #region Global Attributes

        public static ScriptEngine Engine;
        public static ScriptRuntime Py;
        public static dynamic Capi;

        public static bool Initialized = false;

        #endregion

        #region Challonge

        public static void Initialize ()
        {
            /* Create engine and add challonge to path */
            Engine = Python.CreateEngine();
            Py = Python.CreateRuntime();
            Capi = Py.UseFile("src/pychallonge/challonge/api.py");

            Initialized = true;
        }

        /* Sets credentials of user and tests if credentials are valid */
        public static async Task<bool> SetCredentials (string username, string apiKey)
        {
            bool validated = await Challonge.AuthenticateLogin(username, apiKey);
            if (validated)
            {
                if (!Initialized)
                    Initialize();

                Capi.SetCredentials(username, apiKey);

                return true;
            }

            return false;
        }

        #endregion

        #region Example Code

        /* Example on how to create and execute python code */
        public static void PythonCodeExample ()
        {
            ScriptEngine py = Python.CreateEngine();
            ScriptScope s = py.CreateScope();

            py.Execute("x = dir()", s);
            Console.WriteLine(s.GetVariable("x"));
        }

        /* Example on how to execute python scripts.
         * NOTE: scripts are held in bin\Debug */
        public static void PythonFileExecutionExample ()
        {
            ScriptRuntime py = Python.CreateRuntime();
            dynamic testFile = py.UseFile("test.py");
            testFile.Simple();
        }

        #endregion
    }
}
