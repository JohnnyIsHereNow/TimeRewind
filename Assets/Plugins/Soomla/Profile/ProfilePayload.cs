#if  UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using System;
using UnityEngine;
namespace Soomla.Profile
{
	/// <summary>
	/// This class represents the profile payload which is based on
	/// the user payload and additional information.
	/// </summary>
	internal static class ProfilePayload
	{
		public static JSONObject ToJSONObj(string userPayload, string rewardId = "")
		{
			JSONObject obj = new JSONObject(JSONObject.Type.OBJECT);
			obj.AddField(USER_PAYLOAD, userPayload);
			obj.AddField(REWARD_ID, rewardId);
			return obj;
		}

		public static string GetUserPayload(JSONObject profilePayloadJson)
		{
			return profilePayloadJson [USER_PAYLOAD].str;
		}

		public static string GetRewardId(JSONObject profilePayloadJson)
		{
			return profilePayloadJson [REWARD_ID].str;
		}
	
		private const string USER_PAYLOAD = "userPayload";
		private const string REWARD_ID = "rewardId";
	}
}
#endif
