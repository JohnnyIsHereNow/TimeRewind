#if  UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
using UnityEngine;
using System.Collections;

namespace Facebook
{
    public class AndroidFacebookLoader : FB.CompiledFacebookLoader
    {

        protected override IFacebook fb
        {
            get
            {
                return FBComponentFactory.GetComponent<AndroidFacebook>();
            }
        }
    }
}
#endif