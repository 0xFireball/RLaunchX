using Newtonsoft.Json;
using RLaunchX.Types;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

namespace RLaunchX
{
    public class Program
    {
        private readonly static string s_configurationFile = "rlaunch.json";

        public static void Main(string[] args)
        {
            var config = JsonConvert.DeserializeObject<RLaunchConfiguration>(
                File.ReadAllText(s_configurationFile)
            );
            foreach (var launchParams in config.Applications)
            {
                Task.Factory.StartNew(() =>
                {
                    var appAsm = Assembly.Load(AssemblyLoadContext.GetAssemblyName(launchParams.Path));
                    appAsm.EntryPoint.Invoke(null, launchParams.Arguments);
                });
            }
            Thread.CurrentThread.Join();
        }
    }
}