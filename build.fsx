
// FIXME

open Fake.DotNet.NuGet
open Fake.DotNet.NuGet
#r "paket:
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.IO.FileSystem
nuget Fake.IO.Zip
nuget Fake.Windows.Chocolatey
nuget Fake.Tools.Git
nuget Fake.DotNet.MSBuild prerelease
nuget Fake.DotNet.NuGet
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators //enables !! and globbing
open Fake.DotNet
open Fake.IO
open System.IO
open Fake.Tools.Git
open Fake.Windows.Choco

let mutable buildVersion = "5.0.0"

Target.create "Clean" (fun _ ->
    !! "**/bin"
    ++ "**/obj"
    ++ "bin"
    |> Shell.cleanDirs
)


Target.create "Build" (fun _ ->
    let setParams (defaults:MSBuildParams) =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Build"]
            Properties =
                [
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", "Release"
                ]
         }


    MSBuild.build setParams "xmlsyringe.sln"
)




// start build
Target.runOrDefault "Build"
