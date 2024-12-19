using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.VisibleEventInterface
{
    public interface IVisibleEventRepository
    {
        Task<List<VisibleEvent>> GetAllVisibleEvent();
        Task CreateVisibleEvent(VisibleEvent visibleEvent);
    }
}
