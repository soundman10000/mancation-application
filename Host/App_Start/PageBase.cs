// Mancation fucker
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using System.Web.UI;
using ServiceStack;
using ServiceStack.Caching;

namespace Host.App_Start
{
    public class CustomUserSession : AuthUserSession
    {
        public string CustomProperty { get; set; }
    }

    public class PageBase : Page
    {
        protected CustomUserSession UserSession => SessionAs<CustomUserSession>();
        public new ICacheClient Cache => HostContext.Resolve<ICacheClient>();
        private ISessionFactory sessionFactory;
        public virtual ISessionFactory SessionFactory
            => sessionFactory ?? (sessionFactory = HostContext.Resolve<ISessionFactory>()) ?? new SessionFactory(Cache);

        private object userSession;
        protected virtual TUserSession SessionAs<TUserSession>()
        {
            return (TUserSession)(userSession ?? (userSession = Cache.SessionAs<TUserSession>()));
        }

        private ISession sessionBag;
        public new ISession SessionBag => sessionBag ?? (sessionBag = SessionFactory.GetOrCreateSession());

        public void ClearSession()
        {
            userSession = null;
            this.Cache.Remove(SessionFeature.GetSessionKey());
        }
    }
}
