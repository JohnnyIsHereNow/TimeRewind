#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections;


namespace Soomla {	

	/// <summary>
	/// A specific type of <code>Reward</code> that represents a badge
	/// with an icon. For example: when the user achieves a top score,
	/// the user can earn a "Highest Score" badge reward.
	/// </summary>
	public class BadgeReward : Reward {
		public string IconUrl;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="id">see parent</param>
		/// <param name="name">see parent</param>
		public BadgeReward(string id, string name)
			: base(id, name)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="id">see parent</param>
		/// <param name="name">see parent</param>
		/// <param name="iconUrl">A url to the icon of this Badge on the device.</param>
		public BadgeReward(string id, string name, string iconUrl)
			: base(id, name)
		{
			IconUrl = iconUrl;
		}

		/// <summary>
		/// see parent.
		/// </summary>
		public BadgeReward(JSONObject jsonReward)
			: base(jsonReward)
		{
			IconUrl = jsonReward[JSONConsts.SOOM_REWARD_ICONURL].str;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <returns>see parent</returns>
		public override JSONObject toJSONObject() {
			JSONObject obj = base.toJSONObject();
			obj.AddField(JSONConsts.SOOM_REWARD_ICONURL, IconUrl);
			
			return obj;
		}

		protected override bool giveInner() {
			
			// nothing to do here... the parent Reward gives in storage
			return true;
		}

		protected override bool takeInner() {
			// nothing to do here... the parent Reward takes in storage
			return true;
		}

	}
}
#endif
