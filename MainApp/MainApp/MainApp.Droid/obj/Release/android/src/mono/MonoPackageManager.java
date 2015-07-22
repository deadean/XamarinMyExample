package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	public static void LoadApplication (Context context, String runtimeDataDir, String[] apks)
	{
		synchronized (lock) {
			if (!initialized) {
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = context.getApplicationInfo ().dataDir + "/lib";
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						runtimeDataDir,
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				initialized = true;
			}
		}
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		"MainApp.Droid.dll",
		"ExifLib.dll",
		"FormsViewGroup.dll",
		"GalaSoft.MvvmLight.dll",
		"GalaSoft.MvvmLight.Extras.dll",
		"GalaSoft.MvvmLight.Platform.dll",
		"MainApp.dll",
		"MainApp.Services.dll",
		"Microsoft.Practices.ServiceLocation.dll",
		"Mutzl.MvvmLight.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Xaml.dll",
		"System.Diagnostics.Tracing.dll",
		"System.Reflection.Emit.dll",
		"System.Reflection.Emit.ILGeneration.dll",
		"System.Reflection.Emit.Lightweight.dll",
		"System.ServiceModel.Security.dll",
		"System.Threading.Timer.dll",
		"MainApp.UI.Common.dll",
		"Library.dll",
		"MainApp.Data.dll",
		"MainProject.Common.dll",
		"MainApp.UI.Data.dll",
		"SQLite.Net.dll",
		"SQLiteNetExtensions.dll",
		"Newtonsoft.Json.dll",
		"MainApp.UI.Services.dll",
		"XLabs.Platform.dll",
		"XLabs.Core.dll",
		"XLabs.Ioc.dll",
		"MainApp.UI.Common.VVms.dll",
		"MainApp.UI.DataBases.dll",
		"SQLite.Net.Async.dll",
		"SQLiteNetExtensionsAsync.dll",
		"MainApp.UI.Common.Views.dll",
		"XLabs.Forms.dll",
		"XLabs.Serialization.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = null;
}
