using Windows.UI.Xaml.Controls;
using System.Reactive.Linq;
using System;
using System.Threading.Tasks;
using System.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Observables
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var list = new[] { "Item A", "Item B", "Item D", "Item E", "Item F" }.ToObservable();

            Observable.Zip(list, Observable.Interval(TimeSpan.FromSeconds(1)), (a, b) => new { Name = a, WhenItWasCreated = b })
                .ObserveOnDispatcher()
                .Subscribe(x => timer.Text = $"{x.Name} - {x.WhenItWasCreated}", () => timer.Text = "Done!");
        }
    }
}
