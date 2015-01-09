/// Copyright (C) 2012-2014 Soomla Inc.
//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Soomla
{
	public interface ISoomlaPostBuildTool {
#if UNITY_EDITOR
		string GetToolMetaData(BuildTarget target);
#endif
	}
}
//#endif