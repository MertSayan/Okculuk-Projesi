using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.GoogleFormInterface
{
    public interface IGoogleFormRepository
    {
        Task<List<GoogleForm>> GetAllGoogleForm();
        Task CreateGoogleForm(string Id);
        Task DeleteDataTable();

    }
}
