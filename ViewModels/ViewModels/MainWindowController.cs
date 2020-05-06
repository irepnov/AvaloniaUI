using ViewModels;
using ReactiveUI;
using Services;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Linq;
using System.Linq;

namespace ViewModels
{
    //public sealed class MainWindowController
    //{
    //    private readonly IPhoneRepositoryAsync _phoneRepositoryAsync;
    //   // public ObservableAsPropertyHelper<IEnumerable<RxPhone>> _phones { get; set; }
    //    private readonly MainWindowModel _model;
    //    public MainWindowController(IPhoneRepositoryAsync repository)
    //    {
    //        _phoneRepositoryAsync = repository;           
    //    }
    //    public MainWindowController(MainWindowModel model)
    //        :this(Locator.Current.GetService<IPhoneRepositoryAsync>())
    //    {
    //        _model = model;
    //       /* _phones = _model.RefreshCommand
    //             .Select(phones => phones.Select(phone => new RxPhone(phone.Id, phone.Title)))
    //             .ObserveOn(RxApp.MainThreadScheduler)
    //             .ToProperty(_model, x => x.Phones);*/
    //    }
    //    public IDisposable BindExitCommand()
    //    {
    //        _model.ExitCommand = ReactiveCommand.Create(
    //            () => { }, null, RxApp.MainThreadScheduler);
    //        return _model.ExitCommand.SubscribeWithLog();
    //    }
    //    public IDisposable BindTestCommand()
    //    {
    //        _model.TestCommand = ReactiveCommand.Create(
    //            () => { _model.Title = "testtt"; }, null, RxApp.MainThreadScheduler);
    //        return _model.TestCommand.SubscribeWithLog(
    //            () => { _model.Title = "hhhhh";  }
    //        );
    //    }
    //    public IDisposable BindRefreshCommand()
    //    {
    //        _model.RefreshCommand = ReactiveCommand.CreateFromTask(
    //            () => _phoneRepositoryAsync.GetAllAsEnumerable(), null, RxApp.MainThreadScheduler);

    //        _model.RefreshCommand?
    //            .Select(phones => phones.Select(phone => new RxPhone(phone.Id, phone.Title)))
    //            .ObserveOn(RxApp.MainThreadScheduler)
    //            .ToProperty(_model, x => x.Phones);

    //        //_model.RefreshCommand?
    //        //     .Select(phones => phones.Select(phone => new RxPhone(phone.Id, phone.Title)))
    //        //     .ObserveOn(RxApp.MainThreadScheduler)
    //        //     .Subscribe(phones => _model.Phones = phones);
    //            // .BindTo(_model, x => _model.Phones);
    //             //.ToProperty(this, x => x.Phones);

    //        return _model.RefreshCommand.Subscribe();
    //    }
    //    public IDisposable BindWindowTitle()
    //    {
    //        return _model.WhenAnyValue(m => m.Title)
    //            .SubscribeWithLog(title =>
    //            {
    //                if (string.IsNullOrWhiteSpace(title) || title == "…")
    //                {
    //                    _model.Title = "Radish";
    //                }
    //                else
    //                {
    //                    _model.Title = "Radish - " + title;
    //                }
    //            });
    //    }
    //    //public IDisposable BindListPhones()
    //    //{
    //    //    /*
    //    //     _refresh
    //    //         .Select(phones => phones.Select(phone => new RxPhone(phone.Id, phone.Title)))
    //    //         .ObserveOn(_sheduler)
    //    //         .ToProperty(this, x => x.Phones);


    //    //     */
    //    //    /*return _model.WhenAnyValue(m => m.RefreshCommand)
    //    //        .SubscribeWithLog(phones =>
    //    //        {
    //    //            _model.Phones = phones;
    //    //        });*/
    //    //}


    //}
}
