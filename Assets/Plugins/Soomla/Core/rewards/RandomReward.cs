#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Soomla {	

	/// <summary>
	/// A specific type of <code>Reward</code> that holds of list of other
	/// rewards. When this reward is given, it randomly chooses a reward from
	///	the list of rewards it internally holds.  For example: a user can earn a mystery box
	///	reward (<code>RandomReward</code>, which in fact grants the user a random reward between a
	/// "Mayor" badge (<code>BadgeReward</code>) and a speed boost (<code>VirtualItemReward</code>)
	/// </summary>
	public class RandomReward : Reward {
		private static string TAG = "SOOMLA RandomReward";
		public List<Reward> Rewards;
		public Reward LastGivenReward;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="id">see parent.</param>
		/// <param name="name">see parent.</param>
		/// <param name="rewards">A list of rewards from which to choose the reward randomly.</param>
		public RandomReward(string id, string name, List<Reward> rewards)
			: base(id, name)
		{
			if ((Rewards == null || Rewards.Count == 0)) {
				SoomlaUtils.LogError(TAG, "This reward doesn't make sense without items");
			}
			Rewards = rewards;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="jsonReward">see parent.</param>
		public RandomReward(JSONObject jsonReward)
			: base(jsonReward)
		{
			List<JSONObject> rewardsObj = jsonReward[JSONConsts.SOOM_REWARDS].list;
			if ((rewardsObj == null || rewardsObj.Count == 0)) {
				SoomlaUtils.LogWarning(TAG, "Reward has no meaning without children");
				rewardsObj = new List<JSONObject>();
			}

			Rewards = new List<Reward>();
			foreach(JSONObject rewardObj in rewardsObj) {
				Rewards.Add(Reward.fromJSONObject(rewardObj));
			}
		}

		/// <summary>
		/// see parent.
		/// </summary>
		/// <returns>see parent.</returns>
		public override JSONObject toJSONObject() {
			JSONObject obj = base.toJSONObject();

			JSONObject rewardsObj = new JSONObject(JSONObject.Type.ARRAY);
			foreach(Reward r in Rewards) {
				rewardsObj.Add(r.toJSONObject());
			}
			obj.AddField(JSONConsts.SOOM_REWARDS, rewardsObj);
			
			return obj;
		}

		protected override bool giveInner() {
			List<Reward> canBeGivenRewards = new List<Reward>();
			foreach(Reward reward in Rewards) {
				if (reward.CanGive()) {
					canBeGivenRewards.Add(reward);
				}
			}

			if (canBeGivenRewards.Count == 0) {
				SoomlaUtils.LogDebug(TAG, "No more rewards to give in this Random Reward: " + this.ID);
				return false;
			}

			System.Random rand = new System.Random();
			int n = rand.Next(canBeGivenRewards.Count);
			Reward randomReward = canBeGivenRewards[n];
			randomReward.Give();
			LastGivenReward = randomReward;
			
			return true;
		}

		protected override bool takeInner() {
			// for now is able to take only last given
			if(LastGivenReward == null) {
				return false;
			}
			
			bool taken = LastGivenReward.Take();
			LastGivenReward = null;
			
			return taken;
		}

	}
}
#endif