#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Soomla {
	
	public class RewardStorageIOS : RewardStorage {

#if UNITY_IOS && !UNITY_EDITOR
		[DllImport ("__Internal")]
		private static extern long rewardStorage_GetLastGivenTimeMillis(string rewardId);
		[DllImport ("__Internal")]
		private static extern int rewardStorage_GetTimesGiven(string rewardId);
		[DllImport ("__Internal")]
		private static extern void rewardStorage_SetTimesGiven(string rewardId, 
		                                                             [MarshalAs(UnmanagedType.Bool)] bool up, 
		                                                             [MarshalAs(UnmanagedType.Bool)] bool notify);
		[DllImport ("__Internal")]
		private static extern int rewardStorage_GetLastSeqIdxGiven(string rewardId);
		[DllImport ("__Internal")]
		private static extern void rewardStorage_SetLastSeqIdxGiven(string rewardId, int idx);
		
		/// <summary>
		/// Get last id of given reward from a <c>SequenceReward</c>
		/// </summary>
		/// <param name="reward">to query</param>
		/// <returns>last index of sequence reward given</returns>
		override protected int _getLastSeqIdxGiven(SequenceReward seqReward) {
			return rewardStorage_GetLastSeqIdxGiven(seqReward.ID);
		}
		
		/// <summary>
		/// Set last id of given reward from a <c>SequenceReward</c>
		/// </summary>
		/// <param name="reward">to set last id for</param>
		/// <param name="reward">the last id to to mark as given</param>
		override protected void _setLastSeqIdxGiven(SequenceReward seqReward, int idx) {
			rewardStorage_SetLastSeqIdxGiven(seqReward.ID, idx);
		}

		override protected void _setTimesGiven(Reward reward, bool up, bool notify) {
			rewardStorage_SetTimesGiven(reward.ID, up, notify);
		}
		
		override protected int _getTimesGiven(Reward reward) {
			int times = rewardStorage_GetTimesGiven(reward.ID);
			SoomlaUtils.LogDebug("SOOMLA/UNITY RewardStorageIOS", string.Format("reward {0} given={1}", reward.ID, times));
			return times;
		}

		override protected DateTime _getLastGivenTime(Reward reward) {
			long lastTime = rewardStorage_GetLastGivenTimeMillis(reward.ID);
			TimeSpan time = TimeSpan.FromMilliseconds(lastTime);
			return new DateTime(time.Ticks);
		}
#endif
	}
}
#endif