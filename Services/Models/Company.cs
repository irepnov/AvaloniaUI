using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Company : BaseEntity
    {
        [Reactive] public string Name { get; set; }
        [Reactive] public string INN { get; set; }
        public Company() : base() { }
        public Company(int id = 0, string name = null, string inn = null) : base(id)
        {
            Name = name;
            INN = inn;
        }
    }
}
