#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using UnityEngine;
using System.Collections;

namespace Facebook
{
    public class IOSFacebookLoader : FB.CompiledFacebookLoader
    {

        protected override IFacebook fb
        {
            get
            {
                return FBComponentFactory.GetComponent<IOSFacebook>();
            }
        }
    }
}
#endif