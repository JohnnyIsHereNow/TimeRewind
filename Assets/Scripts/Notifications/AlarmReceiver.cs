using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class AlarmReceiver : MonoBehaviour {
#if UNITY_ANDROID && !UNITY_EDITOR
	AndroidJavaObject nativeObj =null;
#endif


 
  void Start(){
#if UNITY_ANDROID && !UNITY_EDITOR
      if (nativeObj ==null)
        nativeObj =new AndroidJavaObject("com.macaronics.notification.AlarmReceiver");

      nativeObj.CallStatic("startAlarm", new object[4]{"Time rewind", "Help me win !", "You have to do this !", 3600});
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		LocalNotification lc = new LocalNotification();
		lc.alertBody="Help me win !What are you waiting for ?";
		lc.applicationIconBadgeNumber=3;
		lc.fireDate = DateTime.Now.AddHours(60);
		lc.repeatInterval=CalendarUnit.Day;
		NotificationServices.ScheduleLocalNotification(lc);
#endif
  }
}
