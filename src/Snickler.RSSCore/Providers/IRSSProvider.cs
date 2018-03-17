using System.Collections.Generic;
using System.Threading.Tasks;
using Snickler.RSSCore.Models;
namespace Snickler.RSSCore.Providers
{
    public interface IRSSProvider
    {
        Task<IList<RSSItem>> RetrieveSyndicationItems();
    }
}