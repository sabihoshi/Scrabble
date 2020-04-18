using System.Windows.Controls;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using StyletIoC;

namespace Scrabble.ViewModels
{
    public class RackViewModel
    {
        private const int MaxSize = 7;
        private readonly IContainer _ioc;

        public RackViewModel(Player player, IContainer ioc)
        {
            Player = player;
            _ioc = ioc;
            FillRack(MaxSize);
        }

        public BindableCollection<ITile> Tiles { get; set; } = new BindableCollection<ITile>();

        public Player Player { get; set; }

        public Orientation Orientation { get; set; }

        public void FillRack(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var tile = new RackTile(Player, _ioc);
                Tiles.Add(tile);
            }
        }
    }
}