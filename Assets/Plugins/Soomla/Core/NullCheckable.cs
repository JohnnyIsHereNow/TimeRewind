//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections;

/// Extend this class if you want to use the syntax
///	<c>if(myObject)</c> to check if it is not null
public class NullCheckable {

	public static implicit operator bool(NullCheckable o) {
		return (object)o != null;
	}
}
//#endif