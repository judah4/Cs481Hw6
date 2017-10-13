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
        private string[] _mapTypes;

        public MainPage()
        {
            InitializeComponent();
            var mapPos = MapSpan.FromCenterAndRadius(new Position(33.125485, -117.252993), Distance.FromMiles(6));
            MyMap.MoveToRegion(mapPos);

            Place(new Position(33.129351, -117.159253), PinType.Place, "School", "Csusm");
            Place(new Position(33.168389, -117.213174), PinType.Place, "Delicious Burritos at Chitos", "320 Sycamore Ave, Vista, CA 92083");
            Place(new Position(33.149214, -117.183369), PinType.Place, "School", "Palomar");
            Place(new Position(33.161259, -117.346917), PinType.Place, "Lots of fish at Pokewan", "2958 Madison St #101, Carlsbad, CA 92008");
            Place(new Position(33.137090, -117.177160), PinType.Place, "Can't beat In-N-Out for burgers", "583 Grand Ave, San Marcos, CA 92078");

            _mapTypes = Enum.GetNames(typeof(MapType));

            MapPicker.ItemsSource = _mapTypes;
            MapPicker.SelectedIndex = (int) MyMap.MapType;
        }

        private void Place(Position position, PinType pinType, string label, string address)
        {
            var pin = new Pin() {Type = pinType, Position = position, Label = label, Address = address};
            MyMap.Pins.Add(pin);
        }

        private void MapPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            MyMap.MapType = (MapType) MapPicker.SelectedIndex;
        }
    }
}
