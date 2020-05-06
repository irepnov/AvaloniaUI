using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;
using Services;

namespace ViewModels
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class RxPhone : Phone
#pragma warning restore CS0659
    {
        private readonly ObservableAsPropertyHelper<string> _TitleWithCompany;
        public string TitleWithCompany => _TitleWithCompany.Value;
        public RxPhone(int id = 0, string title = null) : base(id, title)
        {
            _TitleWithCompany = this.WhenAnyValue(m => "Test Company", m => m.Title)
                                         .Select(t => $"{t.Item1} {t.Item2}")
                                         .ToProperty(this, m => m.TitleWithCompany);
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                RxPhone p = (RxPhone)obj;
                return (this.Id == p.Id);
            }
        }
    }
}
