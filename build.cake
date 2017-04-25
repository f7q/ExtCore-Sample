var target          = Argument("target", "Default");
var configuration   = Argument<string>("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var packPath1            = Directory("./src/WebApplication");
var packPath2            = Directory("./src/WebApplication.EFCoreRawQuery");
var packPath3            = Directory("./src/WebApplication.Elm");
var packPath4            = Directory("./src/WebApplication.ExtensionA");
var packPath5            = Directory("./src/WebApplication.ExtensionB");
var packPath6            = Directory("./src/WebApplication.NLog");
var packPath7            = Directory("./src/WebApplication.Script");
var packPath8            = Directory("./src/WebApplication.Swagger");
var packPath9            = Directory("./src/WebApplication.WebAPI");
var packPath10           = Directory("./src/DomainModel/Extentions");
var buildArtifacts       = Directory("./artifacts/packages");

var isAppVeyor          = AppVeyor.IsRunningOnAppVeyor;
var isWindows           = IsRunningOnWindows();
var netcore             = "netcoreapp1.0";
var netstandard         = "netstandard1.6";

///////////////////////////////////////////////////////////////////////////////
// Clean
///////////////////////////////////////////////////////////////////////////////
Task("Clean")
    .Does(() =>
{
    CleanDirectories(new DirectoryPath[] { buildArtifacts });
});

///////////////////////////////////////////////////////////////////////////////
// Restore
///////////////////////////////////////////////////////////////////////////////
Task("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreRestoreSettings
    {
        Sources = new [] { 
            "packages",
            "https://api.nuget.org/v3/index.json" 
        }
    };

    var projects = GetFiles("./**/*.csproj");

	foreach(var project in projects)
	{
	    DotNetCoreRestore(project.GetDirectory().FullPath, settings);
    }
});

///////////////////////////////////////////////////////////////////////////////
// Build
///////////////////////////////////////////////////////////////////////////////
Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings 
    {
        Configuration = configuration
    };

    // libraries
	var projects = GetFiles("./src/**/*.csproj");

    if (!isWindows)
    {
        Information("Not on Windows - building only for " + netstandard);
        settings.Framework = netstandard;
    }

    /*
	foreach(var project in projects)
	{
	    DotNetCoreBuild(project.GetDirectory().FullPath, settings); 
    }
    */
    //settings.Framework = netstandard;
    DotNetCoreBuild(packPath2, settings);
    DotNetCoreBuild(packPath3, settings);
    DotNetCoreBuild(packPath4, settings);
    DotNetCoreBuild(packPath5, settings);
    DotNetCoreBuild(packPath6, settings);
    DotNetCoreBuild(packPath7, settings);
    DotNetCoreBuild(packPath8, settings);
    DotNetCoreBuild(packPath9, settings);
    DotNetCoreBuild(packPath10, settings);
    //settings.Framework = netcore;
    DotNetCoreBuild(packPath1, settings);

    // tests
	projects = GetFiles("./test/**/*.csproj");

    if (!isWindows)
    {
        Information("Not on Windows - building only for " + netcore);
        settings.Framework = netcore;
    }

    /*
	foreach(var project in projects)
	{
	    DotNetCoreBuild(project.GetDirectory().FullPath, settings); 
    }
    */
});

///////////////////////////////////////////////////////////////////////////////
// Test
///////////////////////////////////////////////////////////////////////////////
Task("Test")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
    {
        Configuration = configuration
    };

    var projects = GetFiles("./test/**/*.csproj");

    if (!isWindows)
    {
        Information("Not on Windows - testing only for " + netcore);
        settings.Framework = netcore;
    }

    foreach(var project in projects)
	{
        DotNetCoreTest(project.FullPath, settings);
    }
});

///////////////////////////////////////////////////////////////////////////////
// Pack
///////////////////////////////////////////////////////////////////////////////
Task("Pack")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    if (!isWindows)
    {
        Information("Not on Windows - skipping pack");
        return;
    }

    var settings = new DotNetCorePackSettings
    {
        Configuration = configuration,
        OutputDirectory = buildArtifacts,
    };

    // add build suffix for CI builds
    if(isAppVeyor)
    {
        settings.VersionSuffix = "build" + AppVeyor.Environment.Build.Number.ToString().PadLeft(5,'0');
    }
    //settings.Framework = netstandard;
    DotNetCorePack(packPath2, settings);
    DotNetCorePack(packPath3, settings);
    DotNetCorePack(packPath4, settings);
    DotNetCorePack(packPath5, settings);
    DotNetCorePack(packPath6, settings);
    DotNetCorePack(packPath7, settings);
    DotNetCorePack(packPath8, settings);
    DotNetCorePack(packPath9, settings);
    DotNetCorePack(packPath10, settings);
    //settings.Framework = netcore;
    DotNetCorePack(packPath1, settings);
});


Task("Default")
  .IsDependentOn("Build");
  //.IsDependentOn("Test")
  //.IsDependentOn("Pack");

RunTarget(target);