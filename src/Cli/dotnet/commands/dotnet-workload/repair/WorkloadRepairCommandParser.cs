// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using Microsoft.DotNet.Workloads.Workload.Repair;
using LocalizableStrings = Microsoft.DotNet.Workloads.Workload.Repair.LocalizableStrings;

namespace Microsoft.DotNet.Cli
{
    internal static class WorkloadRepairCommandParser
    {
        public static readonly Option<string> ConfigOption = WorkloadInstallCommandParser.ConfigOption;

        public static readonly Option<string[]> SourceOption = WorkloadInstallCommandParser.SourceOption;

        public static readonly Option<string> VersionOption = WorkloadInstallCommandParser.VersionOption;

        public static readonly Option<VerbosityOptions> VerbosityOption = CommonOptions.VerbosityOption();

        public static Command GetCommand()
        {
            var command = new Command("repair", LocalizableStrings.CommandDescription);

            command.AddOption(VersionOption);
            command.AddOption(ConfigOption);
            command.AddOption(SourceOption);
            command.AddOption(VerbosityOption);
            command.AddWorkloadCommandNuGetRestoreActionConfigOptions();

            command.Handler = CommandHandler.Create<ParseResult>((parseResult) => new WorkloadRepairCommand(parseResult).Execute());

            return command;
        }
    }
}
