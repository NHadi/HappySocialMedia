using Happy5SocialMedia.Common.Infrastructure.Interface;
using Happy5SocialMedia.Common.Repositories;
using Happy5SocialMedia.Message.Domain.Model;
using Happy5SocialMedia.Message.Domain.Model.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Happy5SocialMedia.Common.Global;

namespace Happy5SocialMedia.Message.Infrastructure.Repositories
{
    public class ActivityStatusRepository : EfRepository<ActivityStatus>, IActivityStatusRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly Happy5socialmedia_MessageContext _context;
        public ActivityStatusRepository(Happy5socialmedia_MessageContext context, IDbContextFactory dbContextFactory) : base(context)
        {
            _dbContextFactory = dbContextFactory;
            _context = context;
        }

    }
}
