using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Autopilot.LogViewer.UI.ViewModels
{
    /// <summary>
    /// Base class for ViewModels implementing INotifyPropertyChanged.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets a property value and raises PropertyChanged if the value changed.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">Reference to the backing field.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>True if the value changed; otherwise, false.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
