using System;
using BuildAndDeploy.AgcConsensusDocs.BuildandDeploy;
using CommandLine;

namespace BuildAndDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            var parser = new Parser();

            if (parser.ParseArguments(args, options))
            {
                if (options.Package)
                    Package.CopyPasteZip(options);

                if (!string.IsNullOrEmpty(options.Transfer))
                    Deploy.CopyToServer(options);

                if (options.Deploy == "beta")
                    UpdateServerBeta.Update(options);

                if (options.Deploy == "live")
                    UpdateServerLive.Update(options);

                Environment.Exit(0);
            }
        }
    }
}
