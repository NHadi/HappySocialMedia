using Happy5SocialMedia.Activity.Domain.Model;
using Happy5SocialMedia.Activity.Domain.Model.Repositories.Interface;
using Happy5SocialMedia.Common.Infrastructure.Interface;
using Happy5SocialMedia.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy5SocialMedia.Activity.Infrastructure.Repositories
{
    public class FriendRelationshipRepository : EfRepository<FriendRelationship>, IFriendRelationshipRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly Happy5socialmedia_ActivityContext _context;
        public FriendRelationshipRepository(Happy5socialmedia_ActivityContext context, IDbContextFactory dbContextFactory) : base(context)
        {
            _dbContextFactory = dbContextFactory;
            _context = context;
        }
    }
}
