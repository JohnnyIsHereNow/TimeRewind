//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System;

namespace Soomla
{
	public class KeyValueStorage
	{

		protected const string TAG = "SOOMLA KeyValueStorage"; // used for Log error messages

		static KeyValueStorage _instance = null;
		static KeyValueStorage instance {
			get {
				if(_instance == null) {
					#if UNITY_ANDROID && !UNITY_EDITOR
					_instance = new KeyValueStorageAndroid();
					#elif UNITY_IOS && !UNITY_EDITOR
					_instance = new KeyValueStorageIOS();
					#else
					_instance = new KeyValueStorage();
					#endif
				}
				return _instance;
			}
		}
			
		public static string GetValue(string key) {
			return instance._getValue(key);
		}

		public static void SetValue(string key, string val) {
			instance._setValue(key, val);
		}

		public static void DeleteKeyValue(string key) {
			instance._deleteKeyValue(key);
		}

		virtual protected string _getValue(string key) {
#if UNITY_EDITOR
			return PlayerPrefs.GetString (key);
#else
			return null;
#endif
		}

		virtual protected void _setValue(string key, string val) {
#if UNITY_EDITOR
			PlayerPrefs.SetString (key, val);
#endif
		}

		virtual protected void _deleteKeyValue(string key) {
#if UNITY_EDITOR
			PlayerPrefs.DeleteKey(key);
#endif
		}

	}
}
//#endif
