﻿/// WF.Player.Core - A Wherigo Player Core for different platforms.
/// Copyright (C) 2012-2013  Dirk Weltz <web@weltz-online.de>
/// Copyright (C) 2012-2013  Brice Clocher <contact@cybisoft.net>
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Lesser General Public License as
/// published by the Free Software Foundation, either version 3 of the
/// License, or (at your option) any later version.
/// 
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Lesser General Public License for more details.
/// 
/// You should have received a copy of the GNU Lesser General Public License
/// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Reflection;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Xamarin.Forms;
using WF.Player.Core.Engines;
using Vernacular;

[assembly: Dependency(typeof(WF.Player.iOS.Services.Core.iOSPlatformHelper))]

namespace WF.Player.iOS.Services.Core
{
	public class iOSPlatformHelper : IPlatformHelper
	{
		#region Constructors

		static iOSPlatformHelper()
		{
			try
			{
				entryAssemblyVersion = Version.Parse(Assembly.GetExecutingAssembly().GetName().Version.ToString());
			}
			catch (Exception)
			{
				entryAssemblyVersion = null;
			}
		}

		#endregion

		#region Members

		static Version entryAssemblyVersion; 

		#endregion

		#region Properties

		public string CartridgeFolder
		{
			get { return ""; }
		}

		public string SavegameFolder
		{
			get { return "SaveGame"; }
		}

		public string LogFolder
		{
			get { return "Log"; }
		}

		public string Ok
		{
			get { return Catalog.GetString("Ok"); }
		}

		public string EmptyYouSeeListText
		{
			get { return Catalog.GetString("Nothing of interest"); }
		}

		public string EmptyInventoryListText 
		{
			get { return Catalog.GetString("No items"); }
		}

		public string EmptyTasksListText 
		{
			get { return Catalog.GetString("No new tasks"); }
		}

		public string EmptyZonesListText
		{
			get { return Catalog.GetString("Nowhere to go"); }
		}

		public string EmptyTargetListText 
		{
			get { return Catalog.GetString("Nothing available"); }
		}

		public string PathSeparator
		{
			get { return Path.DirectorySeparatorChar.ToString(); }
		}

		public string Platform
		{
			get { return Environment.OSVersion.Platform.ToString(); }
		}

		public string Device
		{
			get { return String.Format(
					"iPhone {0}",
					Environment.OSVersion.Version.ToString()); }
		}

		public string DeviceId
		{
			get 
			{ 
				// Use MAC Adress of en0 as DeviceId
				foreach (var i in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces ())
					if (i.Id.Equals ("en0")) 
						return i.GetPhysicalAddress ().ToString ();
				return "No Id";
			}
		}

		public string ClientVersion
		{
			get { return entryAssemblyVersion != null ? String.Format("{0}.{1}", NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString(), NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString()) : "Unknown"; }
		}

		public bool CanDispatchOnUIThread
		{
			get { return true; }
		}

		#endregion

		#region Methods

		public void BeginDispatchOnUIThread(Action action)
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() => action());
		}

		#endregion
	}
}
