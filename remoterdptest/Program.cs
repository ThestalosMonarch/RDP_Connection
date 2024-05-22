using MSTSCLib;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;


using System;
using System.Diagnostics;

namespace RemoteDesktopConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipAddress = "ip adress";
            string username = "username";
            string password = "password";

            // Adiciona as credenciais ao gerenciador de credenciais do Windows
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe"),
                    Arguments = $"/generic:TERMSRV/{ipAddress} /user:{username} /pass:{password}",
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            process.Start();
            process.WaitForExit();

            // Inicia o cliente de Remote Desktop com as credenciais salvas
            var rdpProcess = new Process
            {
                StartInfo =
                {
                    FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe"),
                    Arguments = $"/f /v:{ipAddress}",
                    WindowStyle = ProcessWindowStyle.Normal,
                }
            };
            rdpProcess.Start();
        }
    }
}
