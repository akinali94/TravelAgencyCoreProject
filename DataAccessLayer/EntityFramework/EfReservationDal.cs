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
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public EfReservationDal(Context context) : base(context)
        {

        }
        public List<Reservation> GetListWithUserAndDestination()
        {
                return _context.Reservations.Include(x => x.AppUser).Include(x => x.Destination).ToList();
        }
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
                return _context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Active").ToList();
            
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
                return _context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Previous").ToList();
            
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {

                return _context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Waiting for Approval").ToList();
        }

        public void Wait(int id)
        {
                var value = _context.Reservations.Find(id);
                value.Status = "Waiting for Approval";
                _context.Update(value);
                _context.SaveChanges();
        }

        public void Previous(int id)
        {
                var value = _context.Reservations.Find(id);
                value.Status = "Previous";
                _context.Update(value);
                _context.SaveChanges();
          
        }

        public void Active(int id)
        {
                var value = _context.Reservations.Find(id);
                value.Status = "Active";
                _context.Update(value);
                _context.SaveChanges();
        }
    }
}
