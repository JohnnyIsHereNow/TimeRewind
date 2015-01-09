#if  UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using System;

namespace Soomla {

	/// <summary>
	/// This class contains all string names of the keys/vals in the JSON being parsed all around the SDK.
	/// </summary>
	public static class JSONConsts
	{

		/** Global **/
		public const string SOOM_ENTITY_NAME       = "name";
		public const string SOOM_ENTITY_DESCRIPTION= "description";
		public const string SOOM_ENTITY_ID         = "itemId";
		public const string SOOM_CLASSNAME         = "className";
		public const string SOOM_SCHEDULE		   = "schedule";


		/** Reward **/
		
		public const string SOOM_REWARDS           = "rewards";
		public const string SOOM_REWARD_ICONURL    = "iconUrl";


		/** Schedule **/
		public const string SOOM_SCHE_REC	       = "schedRecurrence";
		public const string SOOM_SCHE_RANGES       = "schedTimeRanges";
		public const string SOOM_SCHE_RANGE_START  = "schedTimeRangeStart";
		public const string SOOM_SCHE_RANGE_END	   = "schedTimeRangeEnd";
		public const string SOOM_SCHE_APPROVALS    = "schedApprovals";
	}
}
#endif
