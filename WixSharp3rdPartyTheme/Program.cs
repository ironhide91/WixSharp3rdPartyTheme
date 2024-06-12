using System;
using WixSharp;

namespace WixSharp3rdPartyTheme
{
    internal class Program
    {
        static void Main()
        {
            var project = new ManagedProject("MyProduct",
                              new Dir(@"%ProgramFiles%\My Company\My Product",
                                  new File("Program.cs")));

            project.GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b");

            project.DefaultRefAssemblies.Add("bin\\Debug\\net472\\win-x86\\Wpf.Ui.dll");

            //custom set of UI WPF dialogs
            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add<WixSharp3rdPartyTheme.WelcomeDialog>()
                                            .Add<WixSharp3rdPartyTheme.LicenceDialog>()
                                            .Add<WixSharp3rdPartyTheme.FeaturesDialog>()
                                            .Add<WixSharp3rdPartyTheme.InstallDirDialog>()
                                            .Add<WixSharp3rdPartyTheme.ProgressDialog>()
                                            .Add<WixSharp3rdPartyTheme.ExitDialog>();

            project.ManagedUI.ModifyDialogs.Add<WixSharp3rdPartyTheme.MaintenanceTypeDialog>()
                                           .Add<WixSharp3rdPartyTheme.FeaturesDialog>()
                                           .Add<WixSharp3rdPartyTheme.ProgressDialog>()
                                           .Add<WixSharp3rdPartyTheme.ExitDialog>();

            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            project.BuildMsi();
        }
    }
}