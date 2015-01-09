using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class AlarmReceiver : MonoBehaviour {
	AndroidJavaObject nativeObj =null;


 
  void Start(){
#if UNITY_ANDROID && !UNITY_EDITOR
      if (nativeObj ==null)
        nativeObj =new AndroidJavaObject("com.macaronics.notification.AlarmReceiver");

      nativeObj.CallStatic("startAlarm", new object[4]{"Time rewind", "Help me win !", "You have to do this !", 60*60*24});
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		LocalNotification lc = new LocalNotification();
		lc.alertBody="Help me win !";
		lc.applicationIconBadgeNumber=3;
		lc.fireDate = DateTime.Now.AddSeconds(3);
		lc.repeatInterval=CalendarUnit.Day;
		NotificationServices.ScheduleLocalNotification(lc);
		Debug.Log (lc);
#endif
  }
}
