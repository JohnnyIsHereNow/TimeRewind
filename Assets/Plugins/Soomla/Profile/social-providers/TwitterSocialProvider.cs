#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using System;
using UnityEngine;
using System.Collections.Generic;
using Soomla;

namespace Soomla.Profile
{
	public class TwitterSocialProvider : SocialProvider
	{
		private static string TAG = "SOOMLA TwitterSocialProvider";

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UpdateStatus"/>
		/// </summary>
		public override void UpdateStatus(string status, SocialActionSuccess success, SocialActionFailed fail) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UpdateStory"/>
		/// </summary>
		public override void UpdateStory(string message, string name, string caption, 
		                        string link, string pictureUrl, SocialActionSuccess success, SocialActionFailed fail, SocialActionCancel cancel) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UploadImage"/>
		/// </summary>
		public override void UploadImage(byte[] texBytes, string fileName, string message, SocialActionSuccess success, SocialActionFailed fail, SocialActionCancel cancel) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.GetContacts"/>
		/// </summary>
		public override void GetContacts(ContactsSuccess success, ContactsFailed fail) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Logout"/>
		/// </summary>
		public override void Logout(LogoutSuccess success, LogoutFailed fail) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Login"/>
		/// </summary>
		public override void Login(LoginSuccess success, LoginFailed fail, LoginCancelled cancel) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.IsLoggedIn"/>
		/// </summary>
		public override bool IsLoggedIn() {return false;}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.AppRequest"/>
		/// </summary>
		public override void AppRequest(string message, string[] to, string extraData, string dialogTitle, AppRequestSuccess success, AppRequestFailed fail) {}
		
		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Like"/>
		/// </summary>
		public override void Like(string pageName) {
			SoomlaUtils.LogDebug (TAG, "Like");
			Application.OpenURL("https://www.twitter.com/" + pageName);
		}

		public override bool IsNativelyImplemented(){
			return true;
		}
	}
}
#endif

