//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;

namespace Soomla
{
	public interface ISoomlaSettings
	{
#if UNITY_EDITOR
		void OnSoomlaGUI();
		void OnModuleGUI();
		void OnInfoGUI();
		void OnEnable();
#endif
	}
}
//#endif
