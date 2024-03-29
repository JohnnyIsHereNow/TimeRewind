﻿#if UNITY_ANDROID

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla.Profile {

	/// <summary>
	/// <c>SoomlaProfile</c> for Android. 
	/// This class holds the basic assets needed to operate the Profile module.
	/// 
	/// See comments for functions in parent.
	/// </summary>
	public class SoomlaProfileAndroid : SoomlaProfile {

#if UNITY_ANDROID

		protected override void _initialize(string customParamsJson) {
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "initialize", customParamsJson);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _login(Provider provider, string payload){
			AndroidJNI.PushLocalFrame(100);
			using (AndroidJavaClass unityActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using(AndroidJavaObject unityActivity = unityActivityClass.GetStatic<AndroidJavaObject>("currentActivity")) {
					using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
						ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "login", unityActivity, provider.ToString(), payload);
					}
				}
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _logout (Provider provider){
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "logout", provider.ToString());
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override bool _isLoggedIn(Provider provider) {
			bool loggedIn;
			AndroidJNI.PushLocalFrame(100);
			using (AndroidJavaClass unityActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using(AndroidJavaObject unityActivity = unityActivityClass.GetStatic<AndroidJavaObject>("currentActivity")) {
					using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
						loggedIn = ProfileJNIHandler.CallStatic<bool>(jniSoomlaProfile, "isLoggedIn", unityActivity, provider.ToString());
					}
				}
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
			return loggedIn;
		}

		protected override void _updateStatus(Provider provider, string status, string payload){
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "updateStatus", provider.ToString(), status, payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _updateStory(Provider provider, string message, string name,
		                                     string caption, string description, string link,
		                                     string pictureUrl, string payload){
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "updateStory", provider.ToString(), message, name,
				                                 caption, description, link, pictureUrl, payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _uploadImage(Provider provider, string message, string filePath, string payload){
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "uploadImage", provider.ToString(), message, filePath, payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _getContacts(Provider provider, string payload){
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "getContacts", provider.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override UserProfile _getStoredUserProfile(Provider provider) {
			JSONObject upObj = null;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				string upJSON = ProfileJNIHandler.CallStatic<string>(jniSoomlaProfile, "getStoredUserProfile", provider.ToString());
				if(upJSON != null) {
					upObj = new JSONObject(upJSON);
				}
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);

			if (upObj) {
				return new UserProfile(upObj);
			} else {
				return null;
			}
		}

		protected override void _storeUserProfile(UserProfile userProfile, bool notify) {
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "storeUserProfile",
				                                 userProfile.toJSONObject().ToString());
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

		protected override void _openAppRatingPage() {
			AndroidJNI.PushLocalFrame(100);
			using (AndroidJavaClass unityActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using(AndroidJavaObject unityActivity = unityActivityClass.GetStatic<AndroidJavaObject>("currentActivity")) {
					using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.UnitySoomlaProfile")) {
						ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "openAppRatingPage", unityActivity);
					}
				}
			}

			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

#endif
	}
}
#endif