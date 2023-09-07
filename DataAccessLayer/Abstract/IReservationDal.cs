using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithUserAndDestination();
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByPrevious(int id);

        void Active(int id);
        void Previous(int id);
        void Wait(int id);
    }
}
