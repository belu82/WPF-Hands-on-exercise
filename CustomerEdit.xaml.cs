using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandsOnLab1.ClientEntities;

namespace HandsOnLab1
{
    /// <summary>
    /// Interaction logic for CustomerEdit.xaml
    /// </summary>
    public partial class CustomerEdit : UserControl, INotifyPropertyChanged
    {
        private CustomerUpdate _customer = new CustomerUpdate(123);

        public CustomerEdit()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CanSavE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecuteSave(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Assume the save worked.");
        }

        public CustomerUpdate Customer
        {
            get { return _customer; }

            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    OnPropertyChanged("Customer");
                }
            }
        }
        #region INotifyPropertyChanged Members

#pragma warning disable SA1201 // Elements should appear in the correct order
        /// <summary>
        /// Implicit implementation of the INotifyPropertyChanged.PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Throws the <c>PropertyChanged</c> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that was modified.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
