// Globals.cs

#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Text;
#endregion

namespace AG_DAVSSEES
{
    public static class Globals
    {
        /// <summary>
        /// End user debug ON or Off toggled here. ( true = ON )
        /// </summary>
        public static bool Debug { get; } = false;

        /// <summary>
        /// Default embedded icon resource name used across the add-in
        /// for ribbon buttons, windows, and task dialogs.
        /// </summary>
        public static string Icon { get; } = "AG_DAVSSEES.Resources.icon.ico";

        /// <summary>
        /// Core Revit engine (no UI, no active document)
        /// Available only during OnStartup / OnShutdown.
        /// </summary>
        public static ControlledApplication CtlApp { get; set; } = null;

        /// <summary>
        /// Revit UI shell used to create ribbon/buttons
        /// Has no access to the active document.
        /// </summary>
        public static UIControlledApplication UiCtlApp { get; set; } = null;

        /// <summary>
        /// Live Revit session with access to active document, selection, UI, etc.
        /// Only available inside ExternalCommand or ExternalEvent.
        /// </summary>
        public static UIApplication UiApp { get; set; } = null;

        /// <summary>
        /// Represents the *actual Revit model file* currently open.
        /// You get it from UIApplication or UIDocument.
        /// </summary>
        public static Document Doc { get; set; } = null;

        /// <summary>
        /// Shared error log instance used to collect and report errors
        /// across the entire add-in during the current Revit session.
        /// </summary>
        public static LogInfo ErrorLog { get;} = new LogInfo();

        /// <summary>
        /// Shared success log instance used to collect and successful actions
        /// across the entire add-in during the current Revit session.
        /// </summary>
        public static LogInfo SuccessLog { get; } = new LogInfo();

        /// <summary>
        /// Cancellation flag for stopping batch operations.
        /// </summary>
        public static AG.U.CancelFlagInfo CancelFlag { get; set; } = new AG.U.CancelFlagInfo();

        /// <summary>
        /// Stores ElementId's various information so can retreive it after deleting Element.
        /// </summary>
        public static List<DrawingInfo> Drawings { get; set; } = new List<DrawingInfo>();

        /// <summary>
        /// Global variable for modeless progress Form.
        /// </summary>
        public static xForm.FormProgress DeleteProgressForm { get; set; } = null;

        /// <summary>
        /// Global variable for modeless error log Form.
        /// </summary>
        public static xForm.FormLog ErrorLogForm { get; set; } = null;

        /// <summary>
        /// Global variable for modeless success log Form.
        /// </summary>
        public static xForm.FormLog SuccessLogForm { get; set; } = null;
    }

    /// <summary>
    /// Holds identifying information for Views, Legends, Sheets & Schedules.
    /// </summary>
    public class DrawingInfo
    {
        /// <summary>
        /// View name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The kind of drawing: View (Section), Sheet, Schedule, Legend, etc.
        /// </summary>
        public string DrawingKind { get; set; } = string.Empty;

        /// <summary>
        /// The Revit element identifier associated with the drawing.
        /// </summary>
        public ElementId Id { get; set; } = ElementId.InvalidElementId;

#if REVIT2024UP
        /// <summary>
        /// A composite key in the format: Name,DrawingKind,ElementId.Value
        /// </summary>
        public string KeyString => Name + "," + DrawingKind + "," + Id.Value;

#else
        /// <summary>
        /// A composite key in the format: Name,DrawingKind,ElementId.IntegerValue
        /// </summary>
        public string KeyString => Name + "," + DrawingKind + "," + Id.IntegerValue;
        //public string KeyString { get { return Name + "," + DrawingKind + "," + Id.IntegerValue; } }
#endif
    }

    public class LogInfo
    {
        // int is immutable (any change creates a new value), so it needs a setter.
        // StringBuilder is mutable (the same object grows or changes as you edit it).
        // public int Count uses a private set, public string Full only needs get.

        /// <summary>
        /// Total number of error messages added to the log.
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Full accumulated error log.
        /// </summary>
        /// Long form:
        /// public string Full { get { return sb.ToString(); } }
        public string Full => _sb.ToString();

        StringBuilder _sb = new StringBuilder();

        /// <summary>
        /// Adds an error entry to the log and increments the count.
        /// </summary>
        public void Add(string message, bool skipCount = false)
        {
            if(!skipCount) 
                Count++;

            _sb.AppendLine(message);
        }

        /// <summary>
        /// Clears all logged messages and resets the count to zero.
        /// </summary>
        public void Clear()
        {
            _sb.Clear();
            Count = 0;
        }
    }

}
