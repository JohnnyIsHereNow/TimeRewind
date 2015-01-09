//#if UNITY_STANDALONE || UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class FBAppRequestsFilterGroup: Dictionary<string, object>
{
  public FBAppRequestsFilterGroup(string name, List<string> user_ids)
  {
    this["name"] = name;
    this["user_ids"] = user_ids;
  }
}
//#endif