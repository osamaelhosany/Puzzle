using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Puzzle
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            var cellposition = e.Parameter.ToString().Split(';');
            var x = int.Parse(cellposition[0]);
            var y = int.Parse(cellposition[1]);
            switch (e.Direction)
            {
                case SwipeDirection.Right:
                    y++;
                    break;
                case SwipeDirection.Left:
                    y--;
                    break;
                case SwipeDirection.Up:
                    x--;
                    break;
                case SwipeDirection.Down:
                    x++;
                    break;
                default:
                    break;
            }
            var sum = x + y;
            if (sum >= 0 && sum <= 4)
            {
                var nextitem = ((Image)maingrid.Children.ElementAt((3 * x) + y));
                if (nextitem.Source == null)
                {
                    var item = (Image)sender;
                    nextitem.Source = item.Source;
                    item.Source = null;
                }
            }
        }
    }
}
