using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public EfGuideDal(Context context):base(context)
        {
            
        }
        public void ChangeToFalseByGuide(int id)
        {        
            var values = _context.Guides.Find(id);
            values.Status = false;
            _context.Update(values);
            _context.SaveChanges();
        }

        public void ChangeToTrueByGuide(int id)
        {
            var values = _context.Guides.Find(id);
            values.Status = true;
            _context.Update(values);
            _context.SaveChanges();
        }
    }
}
