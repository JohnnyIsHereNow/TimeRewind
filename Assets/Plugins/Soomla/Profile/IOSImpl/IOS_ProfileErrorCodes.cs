//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;
using UnityEngine;

namespace Soomla.Profile {

	/// <summary>
	/// This class provides error codes for each of the errors available in iOS-profile. 
	/// </summary>
	public static class IOS_ProfileErrorCodes {
		public static int NO_ERROR = 0;
		public static int EXCEPTION_PROVIDER_NOT_FOUND = -301;
		public static int EXCEPTION_USER_PROFILE_NOT_FOUND = -302;

		/// <summary>
		/// Checks the error code and throws the relevant exception.
		/// </summary>
		/// <param name="error">Error code.</param>
		public static void CheckAndThrowException(int error) {
			if (error == EXCEPTION_PROVIDER_NOT_FOUND) {
				Debug.Log("SOOMLA/UNITY Got ProviderNotFoundException exception from 'extern C'");
				throw new ProviderNotFoundException();
			} 
			
			if (error == EXCEPTION_USER_PROFILE_NOT_FOUND) {
				Debug.Log("SOOMLA/UNITY Got UserProfileNotFoundException exception from 'extern C'");
				throw new UserProfileNotFoundException();
			} 
		}
	}
}
//#endif
