using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPhoneRepositoryAsync: IBaseRepositoryAsync<Phone>
    {
        Task<Phone> GetByTitle(string title);
    }
}
