using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.Engine.Models.Config
{
    public class SpriteSheetConfig : IConfig
    {
        public string Name { get; set; }

        public string Texture { get; set; }

        public CellConfig[] Cells { get; set; }
    }
}
