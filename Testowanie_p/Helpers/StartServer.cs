using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eunoia.Net.Collections;

namespace PetClinic.Helpers
{
    public class StartServer
    {
        public static void serverStart()
        {
            //ProcessStartInfo proc = new ProcessStartInfo();
            //proc.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\system32\cmd.exe";
            ////proc.WorkingDirectory = @"c:\Program Files\apache-maven-3.5.0\bin";
            //proc.WorkingDirectory = @"d:\apache-maven-3.5.0\bin";
            //proc.UseShellExecute = false;
            //proc.CreateNoWindow = false;
            //proc.Verb = "OPEN";

            //proc.Arguments = @"/c mvn tomcat7:run";
            //Process.Start(proc);

            //var fdfd = Process.GetProcessesByName("vstest.executionengine.x86");

            ManualResetEvent semaphore = new ManualResetEvent(false);
            bool isError = false;

            ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\system32\cmd.exe";
            startinfo.WorkingDirectory = @"d:\apache-maven-3.5.0\bin";
            startinfo.Arguments = @"/c mvn tomcat7:run";

            Process process = new Process();
            process.StartInfo = startinfo;
            process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += (sender, args) =>
            {
                Console.WriteLine(args.Data);
                Debug.WriteLine(args.Data);


                if (args.Data != null && args.Data.Contains("INFO  DispatcherServlet - FrameworkServlet 'petclinic'"))//"INFO: Starting ProtocolHandler [\"http-bio-8080\"]"))
                {
                    semaphore.Set();
                }
            };

            process.ErrorDataReceived += (sender, args) =>
            {
                Console.WriteLine(args.Data);

                //if (args.Data.Contains("Error") || args.Data.Contains("error") || args.Data.Contains("ERROR"))
                //{
                //    isError = true;
                //    semaphore.Set();
                //}
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            semaphore.WaitOne();

            //int id = process.Id;
            //TestKill(id);
        }

        public static void ServerStop()
        {
            List<ProcesWithPort> netStatResults = NetStatHelper.GetNetStatPorts();
            var tomcatProcess = netStatResults.FirstOrDefault(p => p.PortNumber == "8080");

            if (tomcatProcess == null)
            {
                throw new Exception("BOOOOOOM!");
            }
            else
            {
                Process tomcatProc = Process.GetProcessById(tomcatProcess.Pid);
                tomcatProc.Kill();
            }
        }

        public static uint GetProcId(uint port)
        {
            var at = new TcpTable2().ToArray();

            foreach (var row in at)
            {
                if (row.LocalPort == port)
                {
                    return row.OwningPid;
                }
            }

            return 0;
        }

        public static void TestKill(int procId)
        {


            ProcessStartInfo processStartInfo = new ProcessStartInfo("taskkill", "/F /PID " + procId)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            Process.Start(processStartInfo);
        }
    }
}

