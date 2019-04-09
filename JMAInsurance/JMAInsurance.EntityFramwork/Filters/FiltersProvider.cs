using JMAInsurance.EntityFramwork.Extensibility.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.EntityFramwork.Filters
{
    public class FiltersProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = controllerContext.HttpContext.Resolve<IEnumerable<IPermanentFilter>>();
            return filters.Reverse().Select((filter, index) => new Filter(filter, FilterScope.Action, -(index + 1)));
        }
    }
}
