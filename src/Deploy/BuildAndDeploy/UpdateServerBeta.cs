﻿namespace BuildAndDeploy
{
    public static class UpdateServerBeta
    {
        public static void Update(CommandLineOptions options)
        {
            StartServices();
            ConfigureWebRoot(options);
        }

        private static void ConfigureWebRoot(CommandLineOptions options)
        {
            // Copy files
        }

        private static void StartServices()
        {
            // Start win services
        }
    }
}
