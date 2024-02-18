using Domain.entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.GamePart.Paltform
{
    public class GameSelectedPlatform
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        #region Rels
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        #endregion
    }
}
