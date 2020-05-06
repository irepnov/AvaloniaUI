using ViewModels;
using ReactiveUI;
using Serilog;
using Services;
using Splat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Concurrency;
using System.Text;
using Views;
using System.Reflection;

namespace Avalon
{
    public class Dependences
    {
        public void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton<IApplicationStorage>(() => ApplicationStorage.Instance);
            services.RegisterLazySingleton<IApplicationInfo>(() => new ApplicationInfo(Assembly.GetExecutingAssembly()));
            services.Register<Serilog.ILogger>(
                () =>
                {
                    var storage = resolver.GetService<IApplicationStorage>();
                    return new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File(Path.Combine(storage.LogDirectory, "application.log"))
                        .CreateLogger();
                });
            services.RegisterLazySingleton<IScheduler>(() => RxApp.MainThreadScheduler);

            services.Register<PgApplicationContext>(() => new PgApplicationContext());
            services.Register<IPhoneRepositoryAsync>(() => new PhoneRepositoryAsync(resolver.GetService<PgApplicationContext>()));

            services.RegisterLazySingleton<IDialogProvider>(() => new DialogProvider(typeof(App).Assembly));           
            services.RegisterLazySingleton<IDialogManager>(() => new DialogManager(resolver.GetService<IDialogProvider>()));
           // services.RegisterLazySingleton<IMainViewModel>(() => new MainViewModel(resolver.GetService<IPhoneRepositoryAsync>(), resolver.GetService<IScheduler>()));
        }
    }
}
