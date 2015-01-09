//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System;

namespace Soomla.Profile {

	/// <summary>
	/// This class uses JNI and provides functions that call SOOMLA's android-profile.
	/// </summary>
	public static class ProfileJNIHandler {

#if UNITY_ANDROID

		/// <summary>
		/// Calls android-profile static function that returns void and receives a params arguments. 
		/// </summary>
		public static void CallStaticVoid(AndroidJavaClass jniObject, string method, params object[] args) {
			if(!Application.isEditor){
				jniObject.CallStatic(method, args);

				checkExceptions();
			}
		}

		/// <summary>
		/// Calls android-profile static function that has a return value and receives a string argument. 
		/// </summary>
		/// <param name="jniObject">A type-less instance of any Java class.</param>
		/// <param name="method">The method to call in android-profile.</param>
		/// <param name="args">The method's arguments.</param>
		/// <returns>Return value of the function called.</returns>
		public static T CallStatic<T>(AndroidJavaClass jniObject, string method, params object[] args) {
			if (!Application.isEditor) {
				T retVal = jniObject.CallStatic<T>(method, args);

				checkExceptions();

				return retVal;
			}
			
			return default(T);
		}

		/// <summary>
		/// Throws one of the exceptions (<c>UserProfileNotFoundException</c> or <c>ProviderNotFoundException</c> if needed. 
		/// </summary>
		public static void checkExceptions ()
		{
			IntPtr jException = AndroidJNI.ExceptionOccurred();
			if (jException != IntPtr.Zero) {
				AndroidJNI.ExceptionClear();
				
				AndroidJavaClass jniExceptionClass = new AndroidJavaClass("com.soomla.profile.exceptions.UserProfileNotFoundException");
				if (AndroidJNI.IsInstanceOf(jException, jniExceptionClass.GetRawClass())) {
					Debug.Log("SOOMLA/UNITY Caught UserProfileNotFoundException!");
					
					throw new UserProfileNotFoundException();
				}
				
				jniExceptionClass.Dispose();
				jniExceptionClass = new AndroidJavaClass("com.soomla.profile.exceptions.ProviderNotFoundException");
				if (AndroidJNI.IsInstanceOf(jException, jniExceptionClass.GetRawClass())) {
					Debug.Log("SOOMLA/UNITY Caught ProviderNotFoundException!");
					
					throw new ProviderNotFoundException();
				}

				jniExceptionClass.Dispose();
				
				Debug.Log("SOOMLA/UNITY Got an exception but can't identify it!");
			}
		}
#endif
	}
}
//#endif
