using UnityEngine;
using System;

namespace Soomla {
	
	public class KeyValueStorageAndroid : KeyValueStorage {

#if UNITY_ANDROID && !UNITY_EDITOR

		override protected string _getValue(string key) {
			string val = null;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniRewardStorage = new AndroidJavaClass("com.soomla.data.KeyValueStorage")) {
				val = jniRewardStorage.CallStatic<string>("getValue", key);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
			return val;
		}
		
		override protected void _setValue(string key, string val) {
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniRewardStorage = new AndroidJavaClass("com.soomla.data.KeyValueStorage")) {
				jniRewardStorage.CallStatic("setValue", key, val);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		
		override protected void _deleteKeyValue(string key) {
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniRewardStorage = new AndroidJavaClass("com.soomla.data.KeyValueStorage")) {
				jniRewardStorage.CallStatic("deleteKeyValue", key);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
#endif
	}
}