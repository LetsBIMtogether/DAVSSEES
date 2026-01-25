// App.cs

#region Namespaces
using Autodesk.Revit.UI;
#endregion

namespace AG_DAVSSEES
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            RibbonPanel rPanel = a.CreateRibbonPanel("AG DAVSSEES");
            
            PushButtonData buttonData = new PushButtonData(
                "AG_DAVSSEES",
                "Delete All Views\n... Etc Except",
                AG.U.exeAsm.Location, 
                "AG_DAVSSEES.Command"
                );

            PushButton pButton = rPanel.AddItem(buttonData) as PushButton;
            pButton.ToolTip = "Opens a window where you can Delete All Views, Sheets, Schedules, Etc. Except a Selection.\n(AG DAVSSEES)";
            pButton.LargeImage = AG.U.GetRibbonBitmap(Globals.Icon);

            ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, "https://letsbimtogether.com/__revit/DAVSSEES/F1.html");
            pButton.SetContextualHelp(contextHelp);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
