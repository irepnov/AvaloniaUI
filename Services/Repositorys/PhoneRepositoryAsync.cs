using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PhoneRepositoryAsync : BaseRepositoryAsync<Phone>, IPhoneRepositoryAsync
    {
        public PhoneRepositoryAsync(PgApplicationContext context) : base(context) { }
        public Task<Phone> GetByTitle(string title)
        {
            return FirstOrDefault(w => w.Title == title);
        }
    }
}
