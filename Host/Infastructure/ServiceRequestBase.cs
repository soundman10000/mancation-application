// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Microsoft.Practices.Unity;
using ServiceStack;

namespace Host
{
    public class ServiceRequestBase : Service
    {
        protected ServiceRequestBase()
        {

        }

        protected IUnityContainer Container { get; set; }
        
    }
}