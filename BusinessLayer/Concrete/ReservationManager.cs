using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService  
    {
        IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            return _reservationDal.GetListWithReservationByPrevious(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TActive(int id)
        {
            _reservationDal.Active(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> TGetListWithUserAndDestination()
        {
            var values = _reservationDal.GetListWithUserAndDestination();
            return values;
        }

        public void TPrevious(int id)
        {
            _reservationDal.Previous(id);

        }

        public void TUpdate(Reservation t)
        {
            throw new NotImplementedException();
        }

        public void TWait(int id)
        {
            _reservationDal.Wait(id);
        }
    }
}
