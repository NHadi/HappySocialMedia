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
    public class FriendRequestRepository : EfRepository<FriendRequest>, IFriendRequestRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly Happy5socialmedia_ActivityContext _context;
        public FriendRequestRepository(Happy5socialmedia_ActivityContext context, IDbContextFactory dbContextFactory) : base(context)
        {
            _dbContextFactory = dbContextFactory;
            _context = context;
        }

        public bool HasRelated(Guid UserSender, Guid UserReciever)
        {
            throw new NotImplementedException();
        }
    }
    
}
