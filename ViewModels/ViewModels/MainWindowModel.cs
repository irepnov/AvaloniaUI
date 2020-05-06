using PropertyChanged;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Services;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public sealed class MainWindowModel : BaseViewModel
    {
        private readonly ObservableAsPropertyHelper<IEnumerable<RxPhone>> _phones;
        private readonly ObservableAsPropertyHelper<string> _errorMessage;
        private readonly ObservableAsPropertyHelper<bool> _hasErrors;
        private readonly ObservableAsPropertyHelper<bool> _isBusy;
        private readonly ObservableAsPropertyHelper<int> _countPhones;
        private readonly ReactiveCommand<Unit, IEnumerable<Phone>> _refresh;

        IEnumerable<Phone> MyIterator()
        {
            yield return new Phone(1, "test 1");
            yield return new Phone(2, "test 2");
            yield return new Phone(3, "test 3");
            yield return new Phone(4, "test 4");
            yield return new Phone(5, "test 5");
            yield return new Phone(6, "test 6");
        }

        private Task<IEnumerable<Phone>> getPhones()
        {
            return Task.Run(() =>
            {
                return MyIterator();
            });
        }

        //        private readonly ReactiveCommand<Unit, EditPhoneViewModelResult> _edit;
        public MainWindowModel()
        {
            IScheduler _sheduler = RxApp.MainThreadScheduler;
            IPhoneRepositoryAsync _repos = Locator.Current.GetService<IPhoneRepositoryAsync>();
            //https://itnan.ru/post.php?c=1&p=418007
            //https://github.com/jamilgeor/FormsTutor
            //https://jamilgeor.com/refreshing-a-listview-with-reactivecommand/
            //https://github.com/reactiveui/ReactiveUI#throttling-network-requests-and-automatic-search-execution-behaviour
            //https://dynamic-data.org/category/reactiveui/
            //https://github.com/reactiveui/DynamicData
            //https://oz-code.com/blog/mvvm-gone-reactive-creating-wpf-twitter-client-reactiveui/
            //this.WhenAnyValue(x => x.SearchTerm).InvokeCommand(this, x => x.Search);  если есть данные в троке, то выполняю ReactiveCommand "Search", можно отложить на 1 сек Throttle
            // _refresh = ReactiveCommand.CreateFromTask(() => _repos.GetAllAsEnumerable());

            var t = getPhones();

            _refresh = ReactiveCommand.CreateFromTask(() => getPhones());

            var canEdit = this
                .WhenAnyValue(x => x.SelectedPhone)
                .IsEmpty()
                .Select(x => !x);
            //.Select(x => true);
           /* _edit = ReactiveCommand.CreateFromObservable<Unit, EditPhoneViewModelResult>(
                _ => {
                    return Locator.Current.GetService<IDialogManager>().Open(new EditPhoneViewModel(SelectedPhone));
                }, canEdit, _sheduler);
                */
            _phones = _refresh
                 .Select(phones => phones.Select(phone => new RxPhone(phone.Id, phone.Title)))
                 .ObserveOn(_sheduler)
                 .ToProperty(this, x => x.Phones);
            _errorMessage = _refresh
                .ThrownExceptions
                .Select(exception => exception.Message)
                .Log(this, $"Error refresh data")
                .ObserveOn(_sheduler)
                .ToProperty(this, x => x.ErrorMessage);
            _hasErrors = _refresh
                .ThrownExceptions
                .Select(exception => true)
                .Merge(_refresh.Select(unit => false))
                .ObserveOn(_sheduler)
                .ToProperty(this, x => x.HasErrors);
            _isBusy = _refresh
                .IsExecuting
                .ObserveOn(_sheduler)
                .ToProperty(this, x => x.IsBusy);
          /*  this.WhenAnyValue(vm => vm.Phones)
                .Where(x => x != null)
                .Select(list => list.FirstOrDefault(p => p.Id == 3))
                .Select(item => new RxPhone(item.Id, item.Title))
                .ObserveOn(_sheduler)
                .Subscribe(phone => SelectedPhone = phone);*/
            this.WhenAnyValue(vm => vm.Phones)
                .Where(x => x != null)
                .Select(list => list.Count())
                .ObserveOn(_sheduler)
                .ToProperty(source: this, property: vm => vm.CountPhones, result: out _countPhones, initialValue: 0);
            //this.WhenActivated(disposables =>
            //{
            //    _refresh.Execute().Subscribe().DisposeWith(disposables);
            //});
        }
        public IEnumerable<RxPhone> Phones => _phones.Value;
        [Reactive] public RxPhone SelectedPhone { get; set; }
        public string ErrorMessage => _errorMessage.Value;
        public bool HasErrors => _hasErrors.Value;
        public bool IsBusy => _isBusy.Value;
        public int CountPhones => _countPhones.Value;
        public ICommand Refresh => _refresh;
       // public ICommand Edit => _edit;
    }
}
