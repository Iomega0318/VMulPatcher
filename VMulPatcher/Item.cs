using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMulPatcher
{
    public enum FileRecognization
    {
        Unknown,
        Art,
        ArtLand,
        Gump,
        Texture
    }

    public class Item
    {
        public FileRecognization Flag { get; set; }
        public string BitmapName { get; set; }
        public string FilePath { get; set; }
        public List<ushort> Positions { get; set; }

        public Item(FileRecognization aFlag, string aBitmapName, List<ushort> aPositions)
        {
            this.Flag = aFlag;
            this.BitmapName = aBitmapName;
            this.Positions = aPositions;
            this.FilePath = String.Empty;
        }

        public Item(string aBitmapName, List<ushort> aPositions)
        {
            this.Flag = FileRecognization.Unknown;
            this.BitmapName = aBitmapName;
            this.Positions = aPositions;
            this.FilePath = String.Empty;
        }

    }
}
