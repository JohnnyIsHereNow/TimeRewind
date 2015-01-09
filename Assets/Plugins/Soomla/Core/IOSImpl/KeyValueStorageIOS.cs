//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla {
	
	public class KeyValueStorageIOS : KeyValueStorage {

#if UNITY_IOS && !UNITY_EDITOR
		[DllImport ("__Internal")]
		private static extern void keyValStorage_GetValue(string key, out IntPtr outResult);
		[DllImport ("__Internal")]
		private static extern void keyValStorage_SetValue(string key, string val);
		[DllImport ("__Internal")]
		private static extern void keyValStorage_DeleteKeyValue(string key);

		override protected string _getValue(string key) {
			IntPtr p = IntPtr.Zero;
			keyValStorage_GetValue(key, out p);
			string val = Marshal.PtrToStringAnsi(p);
			Marshal.FreeHGlobal(p);
			return val;
		}
		
		override protected void _setValue(string key, string val) {
			keyValStorage_SetValue(key, val);
		}
		
		override protected void _deleteKeyValue(string key) {
			keyValStorage_DeleteKeyValue(key);
		}
#endif
	}
}
//#endif