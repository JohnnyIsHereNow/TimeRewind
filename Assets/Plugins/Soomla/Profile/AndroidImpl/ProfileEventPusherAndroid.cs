#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla.Profile {

	public class ProfileEventPusherAndroid : Soomla.Profile.ProfileEvents.ProfileEventPusher {

#if UNITY_ANDROID && !UNITY_EDITOR

		// event pushing back to native (when using FB Unity SDK)
		protected override void _pushEventLoginStarted(Provider provider, string payload) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLoginStarted", provider.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLoginFinished(UserProfile userProfile, string payload) { 
			if (SoomlaProfile.IsProviderNativelyImplemented(userProfile.Provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLoginFinished", userProfile.toJSONObject().print(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLoginFailed(Provider provider, string message, string payload) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLoginFailed", provider.ToString(), message, payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLoginCancelled(Provider provider, string payload) { 
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLoginCancelled", provider.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLogoutStarted(Provider provider) { 
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLogoutStarted", provider.ToString());
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLogoutFinished(Provider provider) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLogoutFinished", provider.ToString());
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventLogoutFailed(Provider provider, string message) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventLogoutFailed",
				                                 provider.ToString(), message);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventSocialActionStarted(Provider provider, SocialActionType actionType, string payload) { 
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventSocialActionStarted",
				                                 provider.ToString(), actionType.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventSocialActionFinished(Provider provider, SocialActionType actionType, string payload) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventSocialActionFinished",
				                                 provider.ToString(), actionType.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventSocialActionCancelled(Provider provider, SocialActionType actionType, string payload) {
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventSocialActionCancelled",
				                                 provider.ToString(), actionType.ToString(), payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}
		protected override void _pushEventSocialActionFailed(Provider provider, SocialActionType actionType, string message, string payload) { 
			if (SoomlaProfile.IsProviderNativelyImplemented(provider)) return;
			AndroidJNI.PushLocalFrame(100);
			using(AndroidJavaClass jniSoomlaProfile = new AndroidJavaClass("com.soomla.profile.unity.ProfileEventHandler")) {
				ProfileJNIHandler.CallStaticVoid(jniSoomlaProfile, "pushEventSocialActionFailed", 
				                                 provider.ToString(), actionType.ToString(), message, payload);
			}
			AndroidJNI.PopLocalFrame(IntPtr.Zero);
		}

#endif
	}
}
#endif