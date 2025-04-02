using System;
using System.Threading;
using System.Threading.Tasks;
using AvaPlate.Utilities;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AvaPlate.Services;

/// <summary>
/// Modal Error Handler.
/// </summary>
public class ModalErrorHandler : IErrorHandler
{
    SemaphoreSlim _semaphore = new(1, 1);

    /// <summary>
    /// Handle error in UI.
    /// </summary>
    /// <param name="ex">Exception.</param>
    public void HandleError(Exception ex)
    {
        DisplayAlert(ex).FireAndForgetSafeAsync();
    }

    async Task DisplayAlert(Exception ex)
    {
        try
        {
            await _semaphore.WaitAsync();
            var box = MessageBoxManager.GetMessageBoxStandard("Error", ex.Message, ButtonEnum.YesNo);
            await box.ShowAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}