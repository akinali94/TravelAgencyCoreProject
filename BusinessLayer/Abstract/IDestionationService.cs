using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestionationService : IGenericService<Destination>
    {
        public Destination TGetDestionationWithGuide(int id);
        public List<Destination> TGetLast4Destination();
    }
}
