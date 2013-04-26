using System;
using Renci.SshNet;

namespace BuildAndDeploy
{
    public static class Deploy
    {
        public static void CopyToServer(CommandLineOptions options)
        {
            // deploy to target server

            using (var ssh = new SshClient("208.95.242.19", 5639, "deg_admin", "P@ssw0rd2"))
            {
                ssh.Connect();
                ssh.RunCommand(@"/cygdrive/c/windows/system32/inetsrv/appcmd stop apppool /APPPOOL.NAME:AGCCNSNSDCS." + options.Transfer);
                Console.WriteLine("run 7z.exe x AgcConsensusDocsPackage/AgcConsensusDocsFull.zip -oAgcConsensusDocsPackage");
                ssh.RunCommand("run 7z.exe x AgcConsensusDocsPackage/AgcConsensusDocsFull.zip -oAgcConsensusDocsPackage");
                ssh.RunCommand(@"/cygdrive/c/windows/system32/inetsrv/appcmd start apppool /APPPOOL.NAME:AGCCNSNSDCS." + options.Transfer);
                Console.WriteLine("Extraction is complete!");
                Console.WriteLine();
                Console.WriteLine(@"run AgcConsensusDocsPackage/DeployPackage/bin/Debug/AgcConsensusDocs.BuildandDeploy.exe -d " + options.Transfer + " -m " + "\"" + options.Message + "\"");
                ssh.RunCommand(@"run AgcConsensusDocsPackage/DeployPackage/bin/Debug/AgcConsensusDocs.BuildandDeploy.exe -d " + options.Transfer + " -m " + "\"" + options.Message + "\"");
                ssh.RunCommand(@"/cygdrive/c/windows/system32/inetsrv/appcmd start apppool /APPPOOL.NAME:AGCCNSNSDCS." + options.Transfer);
                //ssh.RunCommand(@"wahtever.exe -deploy");
                ssh.Disconnect();
            }
        }
    }
}
