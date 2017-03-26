using System;
using System.Diagnostics;

namespace AutocadHelper
{
	class Program
	{
		public static void CloseAllInstance()
		{
			var aCAD = Process.GetProcessesByName("acad");

			foreach (var aCADPro in aCAD)
			{
				aCADPro.Kill();
			}
		}


		static void Main(string[] args)
		{
			try
			{
				CloseAllInstance();
				Autodesk.AutoCAD.Interop.AcadApplication AcadApp = new Autodesk.AutoCAD.Interop.AcadApplication();
				AcadApp.Application.WindowState = Autodesk.AutoCAD.Interop.Common.AcWindowState.acMax;
				AcadApp.Application.Visible = true;
				int menu_count = AcadApp.Application.MenuBar.Count;
				for (int i = 0; i < menu_count; ++i)
				{
					Console.WriteLine(AcadApp.Application.MenuBar.Item(i).Name);
				}
				int group_count = AcadApp.Application.MenuGroups.Count;
				for (int i = 0; i < group_count; ++i)
				{
					Console.WriteLine(AcadApp.Application.MenuGroups.Item(i).Name);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error:" + e);
			}
			Console.WriteLine("Press key");
			Console.ReadLine();
		}
	}
}
