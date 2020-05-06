using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Phone : BaseEntity
    {
        [Reactive] public string Title { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Phone() : base() { }
        public Phone(int id = 0, string title = null) : base(id)
        {
            Title = title;
        }
    }
}
