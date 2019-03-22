using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DataAccess
{
    public struct EnvironmentValues
    {
        /// <summary>
        /// The user identifier
        /// </summary>
        public const string ADitUId = "KeyUId";

        /// <summary>
        /// The password
        /// </summary>
        public const string ADitPwd = "KeyPwd";

        /// <summary>
        /// The server
        /// </summary>
        public const string ADitSvr = "KeySvr";

        /// <summary>
        /// The email key
        /// </summary>
        public const string EmailKey = "EmailKey";


        /// <summary>
        /// The pay stack key
        /// </summary>
        public const string PayStackKey = "PayStackKey";


        /// <summary>
        /// The pay stack call back
        /// </summary>
        public const string PayStackCallBack = "PayStackCallBack";
    }
}