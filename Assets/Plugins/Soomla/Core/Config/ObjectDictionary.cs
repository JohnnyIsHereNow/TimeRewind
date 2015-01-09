#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public sealed class ObjectKvp : UnityNameValuePair<string> {
	public string value = null;
	
	override public string Value {
		get { return this.value; }
		set { this.value = value; }
	}
	
	public ObjectKvp(string key, string value) : base(key, value) {
	}
}

[System.Serializable]
public class ObjectDictionary : UnityDictionary<string> {
	public List<ObjectKvp> values;
	
	override protected List<UnityKeyValuePair<string, string>> KeyValuePairs {
		get {
			if (values == null) {
				values = new List<ObjectKvp>();
			}
			return values.ConvertAll<UnityKeyValuePair<string,string>>(new System.Converter<ObjectKvp, UnityKeyValuePair<string,string>>(
				x => {
				return x as UnityKeyValuePair<string,string>;
			}));
		}
		set {
			if (value == null) {
				values = new List<ObjectKvp>();
				return;
			}
			
			values = value.ConvertAll<ObjectKvp>(new System.Converter<UnityKeyValuePair<string,string>, ObjectKvp>(
				x => {
				return new ObjectKvp(x.Key, x.Value as string);
			}));
		}
	}
	
	override protected void SetKeyValuePair(string k, string v) {
		var index = values.FindIndex(x => {
			return x.Key == k;});
		
		if (index != -1) {
			if (v == null) {
				values.RemoveAt(index);
				return;
			}
			
			values[index] = new ObjectKvp(k, v);
			return;
		}
		
		values.Add(new ObjectKvp(k, v));
	}
}
#endif