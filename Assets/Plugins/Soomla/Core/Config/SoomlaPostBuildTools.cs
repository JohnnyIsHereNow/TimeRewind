//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections.Generic;

namespace Soomla
{
	public class SoomlaPostBuildTools {
	#if UNITY_EDITOR
		private static Dictionary<string, ISoomlaPostBuildTool> Tools = new Dictionary<string, ISoomlaPostBuildTool>();

		public static void AddTool(string module, ISoomlaPostBuildTool tool) {
			string key = FindToolKey(module);
			if (key == null) {
				Tools.Add(module, tool);
			}
			else {
				Tools[key] = tool;
			}
		}

		public static ISoomlaPostBuildTool GetTool (string targetModule) {
			string key = FindToolKey(targetModule);
			if (key == null) {
				return null;
			}
			else {
				return Tools[key];
			}
		}

		private static string FindToolKey(string targetModule) {
			foreach (var entry in Tools) {
				if (targetModule.ToLower().StartsWith(entry.Key.ToLower())) {
					return entry.Key;
				}
			}

			return null;
		}
	#endif
	}

}
//#endif