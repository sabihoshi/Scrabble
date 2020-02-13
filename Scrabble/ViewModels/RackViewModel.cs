using System.Windows.Controls;
using Scrabble.Models;
using Scrabble.Models.Tile;
using Stylet;
using StyletIoC;

namespace Scrabble.ViewModels
{
    public class RackViewModel
    {
        public const int MaxSize = 7;
        private readonly IContainer _ioc;

        public RackViewModel(IContainer ioc) => _ioc = ioc;

        public BindableCollection<ITile> Tiles { get; set; } = new BindableCollection<ITile>();

        public Player Player { get; set; }

        public Orientation Orientation { get; set; }

        public void AddPlayer(Player player)
        {
            Player = player;
            for (var i = 0; i < MaxSize; i++)
            {
                var tile = new RackTile(player);
                Tiles.Add(tile);
                _ioc.BuildUp(tile);
            }
        }
    }
}