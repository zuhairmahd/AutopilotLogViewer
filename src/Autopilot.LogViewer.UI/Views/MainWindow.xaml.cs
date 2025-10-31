using System.Linq;
using System.Windows;
using Autopilot.LogViewer.UI.ViewModels;

namespace Autopilot.LogViewer.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Subscribe to the ColumnLayoutReset event
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.ColumnLayoutReset += OnColumnLayoutReset;
            }

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Ensure the DataContext event is wired up
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.ColumnLayoutReset -= OnColumnLayoutReset; // Remove if already added
                viewModel.ColumnLayoutReset += OnColumnLayoutReset;
            }
        }

        private void OnColumnLayoutReset(object? sender, System.EventArgs e)
        {
            // Reset the DataGrid columns to their default order
            ResetDataGridColumns();
        }

        private void ResetDataGridColumns()
        {
            // Get default settings
            var defaults = Helpers.ColumnSettings.GetDefaults();

            // Apply to DataGrid columns
            foreach (var setting in defaults)
            {
                var column = LogDataGrid.Columns.FirstOrDefault(c =>
                    c.Header?.ToString() == setting.Header);
                if (column != null)
                {
                    column.DisplayIndex = setting.DisplayIndex;
                }
            }
        }

        /// <summary>
        /// Handles the Exit menu item click.
        /// </summary>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
