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
        public List<Reservation> GetListWithUserAndDestination()
        {
            using(var context  = new Context())
            {
                return context.Reservations.Include(x => x.AppUser).Include(x => x.Destination).ToList();
            }
        }
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Active").ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Previous").ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.AppUserID == id && x.Status == "Waiting for Approval").ToList();
            }
        }

        public void Wait(int id)
        {
            using (var context = new Context())
            {
                var value = context.Reservations.Find(id);
                value.Status = "Waiting for Approval";
                context.Update(value);
                context.SaveChanges();
            }
        }

        public void Previous(int id)
        {
            using (var context = new Context())
            {
                var value = context.Reservations.Find(id);
                value.Status = "Previous";
                context.Update(value);
                context.SaveChanges();
            }
        }

        public void Active(int id)
        {
            using (var context = new Context())
            {
                var value = context.Reservations.Find(id);
                value.Status = "Active";
                context.Update(value);
                context.SaveChanges();
            }
        }
    }
}
