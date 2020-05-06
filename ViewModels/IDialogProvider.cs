using System;

namespace ViewModels
{
    public interface IDialogProvider
    {
        Type GetWindowType(Type contextType);
    }
}