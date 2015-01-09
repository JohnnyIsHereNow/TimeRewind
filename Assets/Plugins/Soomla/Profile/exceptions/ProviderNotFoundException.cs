//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;

namespace Soomla.Profile {

	/// <summary>
	/// Exception that's thrown when a wrong provider was provided to the function.
	/// </summary>
	public class ProviderNotFoundException : Exception {

		/// <summary>
		/// Constructor.
		/// </summary>
		public ProviderNotFoundException ()
			:base("The provider from the last operation doesn't exist!")
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="providerName">The provider that was given and caused the exception.</param>
		public ProviderNotFoundException (string providerName)
			:base("The provider from the last operation doesn't exist: " + providerName)
		{
		}
	}
}

//#endif