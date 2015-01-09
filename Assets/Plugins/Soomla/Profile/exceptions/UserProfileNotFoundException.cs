//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;

namespace Soomla.Profile {

	/// <summary>
	/// An exception that's thrown when the user profile is not found.
	/// </summary>
	public class UserProfileNotFoundException : Exception {

		/// <summary>
		/// Constructor.
		/// </summary>
		public UserProfileNotFoundException ()
			:base("Couldn't find the user profile")
		{
		}
	}
}
//#endif
