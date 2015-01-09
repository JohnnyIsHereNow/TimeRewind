#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using UnityEngine;
using System.Collections;

namespace Facebook
{
    public class CanvasFacebookLoader : FB.RemoteFacebookLoader
    {
        protected override string className
        {
            get { return "CanvasFacebook"; }
        }
    }
}
#endif