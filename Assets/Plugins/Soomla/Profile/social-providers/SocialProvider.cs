#if  UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Soomla.Profile
{

	/// <summary>
	/// This class represents a specific social provider (for example, Facebook, Twitter, etc). 
	/// Each social provider needs to implement the functions in this class.
	/// </summary>
	public abstract class SocialProvider
	{
		public delegate void LoginSuccess(UserProfile userProfile);
		public delegate void LoginFailed(string message);
		public delegate void LoginCancelled();
		public delegate void LogoutFailed(string message);
		public delegate void LogoutSuccess();
		public delegate void ContactsFailed(string message);
		public delegate void ContactsSuccess(List<UserProfile> userProfiles);
		public delegate void UserProfileFailed(string message);
		public delegate void UserProfileSuccess(UserProfile userProfile);
		public delegate void SocialActionFailed(string message);
		public delegate void SocialActionSuccess();
		public delegate void SocialActionCancel();
		public delegate void AppRequestSuccess(string requestId, List<string> recipients);
		public delegate void AppRequestFailed(string message);
		//		public delegate void FeedFailed(string message);
		//		public delegate void FeedSuccess(List<String> feeds);


		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UpdateStatus"/>
		/// </summary>
		public abstract void UpdateStatus(string status, SocialActionSuccess success, SocialActionFailed fail);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UpdateStory"/>
		/// </summary>
		public abstract void UpdateStory(string message, string name, string caption, 
		                                 string link, string pictureUrl, SocialActionSuccess success, SocialActionFailed fail, SocialActionCancel cancel);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.UploadImage"/>
		/// </summary>
		public abstract void UploadImage(byte[] texBytes, string fileName, string message, SocialActionSuccess success, SocialActionFailed fail, SocialActionCancel cancel);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.GetContacts"/>
		/// </summary>
		public abstract void GetContacts(ContactsSuccess success, ContactsFailed fail);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Logout"/>
		/// </summary>
		public abstract void Logout(LogoutSuccess success, LogoutFailed fail);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Login"/>
		/// </summary>
		public abstract void Login(LoginSuccess success, LoginFailed fail, LoginCancelled cancel);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.IsLoggedIn"/>
		/// </summary>
		public abstract bool IsLoggedIn();

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.AppRequest"/>
		/// </summary>
		public abstract void AppRequest(string message, string[] to, string extraData, string dialogTitle, AppRequestSuccess success, AppRequestFailed fail);

		/// <summary>
		/// See docs in <see cref="SoomlaProfile.Like"/>
		/// </summary>
		public abstract void Like(string pageName);

		// TODO: irrelevant for now. Will be updated soon.
		//		public abstract void GetFeed(FeedSuccess success, FeedFailed fail);

		public abstract bool IsNativelyImplemented();

	}
}
#endif
