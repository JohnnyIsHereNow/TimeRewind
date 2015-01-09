//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;
namespace Soomla.Profile
{
	/// <summary>
	/// A string enumeration of available social providers. Currently, the only Provider available 
	/// with SOOMLA is Facebook, but in the future more providers will be supported. 
	/// </summary>
	public sealed class Provider
	{
		private readonly string name;

		public static readonly Provider FACEBOOK = new Provider ("facebook");
		public static readonly Provider GOOGLE = new Provider ("google");
		public static readonly Provider TWITTER = new Provider ("twitter");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">Name of the social provider.</param>
		private Provider(string name){
			this.name = name;
		}

		//// <summary>
		/// Converts this provider into a string. 
		/// </summary>
		/// <returns>A string representation of the current <c>Provider</c>.</returns>
		public override string ToString(){
			return name;
		}

		/// <summary>
		/// Converts the given string into a <c>Provider</c>
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="providerTypeStr">The string to convert into a <c>Provider</c>.</param>
		public static Provider fromString(string providerTypeStr) {
			switch(providerTypeStr) {
			case("facebook"):
				return FACEBOOK;
			case("google"):
				return GOOGLE;
			case("twitter"):
				return TWITTER;
			default:
				return null;
			}
		}

		/// <summary>
		/// Converts the given int into a <c>Provider</c>
		/// </summary>
		/// <returns>The int.</returns>
		/// <param name="providerTypeInt">The string to convert into a <c>Provider</c>.</param>
		public static Provider fromInt(int providerTypeInt) {
			switch(providerTypeInt) {
			case 0:
				return FACEBOOK;
			case 2:
				return GOOGLE;
			case 5:
				return TWITTER;
			default:
				return null;
			}
		}
	}
}

//#endif