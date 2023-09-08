using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EfCommentDal(Context context): base(context)
        {
            
        }
        public List<Comment> GetListCommentwithDestination()
        {
                return _context.Comments.Include(x => x.Destination).ToList();
        }

        public List<Comment> GetListCommentwithDestinationandUser(int id)
        {
            return _context.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser).ToList();
        }
    }
}
