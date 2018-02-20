using System;

using Caliburn.Micro;

namespace ScoroTask.Views
{
    public interface IShellView
    {
        INavigationService CreateNavigationService(WinRTContainer container);
    }
}
