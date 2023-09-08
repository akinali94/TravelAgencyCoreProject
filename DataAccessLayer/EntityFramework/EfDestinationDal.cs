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
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public EfDestinationDal(Context context):base(context)
        {
            
        }
        public Destination GetDestinationWithGuide(int id)
        {
                return _context.Destinations.Where(x => x.DestinationID == id).Include(x => x.DestinationGuide).FirstOrDefault();   
        }

        public List<Destination> GetLast4Destination()
        {

                var values = _context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
                return values;
        }
    }
}
