using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class BaseEntity : ReactiveObject
    {
        [Reactive] public int Id { get; set; }
        public BaseEntity() { }
        public BaseEntity(int id = 0)
        {
            Id = id;
        }
    }



}
