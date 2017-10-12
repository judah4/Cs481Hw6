using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Cs481Hw6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mapPos = MapSpan.FromCenterAndRadius(new Position(33.129351, -117.159253), Distance.FromMiles(1));
            MyMap.MoveToRegion(mapPos);

            Place(new Position(33.129351, -117.159253), PinType.Place, "School", "Csusm");
        }

        private void Place(Position position, PinType pinType, string label, string address)
        {
            var pin = new Pin() {Type = pinType, Position = position, Label = label, Address = address};
            MyMap.Pins.Add(pin);
        }
    }
}
