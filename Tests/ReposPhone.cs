using Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ReposPhone
    {
        private readonly IPhoneRepositoryAsync repos;

        public ReposPhone()
        {
            PgApplicationContext context = new PgApplicationContext();
            repos = new PhoneRepositoryAsync(context);
        }

        [Fact]
        public void InitRepos()
        {
            Assert.NotNull(repos);
        }

        [Fact]
        public async void Test()
        {
            IEnumerable<Phone> allEnumResult = await repos.GetAllAsEnumerable();
            Assert.NotNull(allEnumResult);

            var allQueryResult = repos.GetAllAsQueryable();
            Assert.NotNull(allQueryResult);
        }
    }
}
