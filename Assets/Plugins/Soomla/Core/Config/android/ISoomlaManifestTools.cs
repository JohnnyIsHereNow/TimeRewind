//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using System;
namespace Soomla
{
		public interface ISoomlaManifestTools
		{
#if UNITY_EDITOR
			void UpdateManifest();
#endif
		}
}
//#endif
