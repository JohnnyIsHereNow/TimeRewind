#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections.Generic;

namespace Soomla {

	/// <summary>
	/// This class provides Log functions that output debug and error messages.
	/// </summary>
	public static class SoomlaUtils {

		/// <summary>
		/// Creates Log Debug message according to given tag and message.
		/// </summary>
		/// <param name="tag">The name of the class whose instance called this function.</param>
		/// <param name="message">Debug message to output to log.</param>
		public static void LogDebug(string tag, string message)
		{
			if (Debug.isDebugBuild) {
				Debug.Log(string.Format("{0} {1}", tag, message));
			}
		}

		/// <summary>
		/// Creates Log Error message according to given tag and message.
		/// </summary>
		/// <param name="tag">The name of the class whose instance called this function..</param>
		/// <param name="message">Error message to output to log.</param>
		public static void LogError(string tag, string message) {
			Debug.LogError(string.Format("{0} {1}", tag, message));
		}

		public static void LogWarning(string tag, string message) {
			Debug.LogWarning(string.Format("{0} {1}", tag, message));
		}

		/// <summary>
		/// Returns the class name to be used in serialization/deserialization process
		/// in Soomla
		/// </summary>
		/// <param name="target">The target to get class name for</param>
		/// <returns>The class name of the provided instance</returns>
		public static string GetClassName(object target) {
			return target.GetType().Name;
		}
	}
}
#endif
