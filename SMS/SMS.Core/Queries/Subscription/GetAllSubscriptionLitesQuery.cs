using MediatR;
using SMS.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Queries.Subscription
{
    public class GetAllSubscriptionLitesQuery : IRequest<IEnumerable<SubscriptionLiteViewModel>> { }
}
