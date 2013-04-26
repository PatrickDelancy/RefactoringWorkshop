using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace BuildAndDeploy
{
    public class CommandLineOptions
    {
        [Option('b', "buildandpackage", HelpText = "Package project, pre-deployment")]
        public bool Package { get; set; }

        [Option('t', "transfer", HelpText = "Transfer to server")]
        public string Transfer { get; set; }

        [Option('d', "deploy", HelpText = "Deploy to live or beta")]
        public string Deploy { get; set; }

        [Option('m', "message", HelpText = "Message for PM")]
        public string Message { get; set; }
    }
}
