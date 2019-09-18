using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMulPatchCreator
{
    public enum FileRecognization
    {
        Unknown,
        Art,
        ArtLand,
        Gump,
        Texture
    }

    public enum ConfigMode
    {
        None,
        Individually,
        Multiple,
        Range
    }

    public class ConfigItem
    {
        public Bitmap UOBitmap { get; set; }
        public FileRecognization Flag { get; set; }
        public ConfigMode ConfigFlag { get; set; }
        public List<ushort> UOPositions { get; set; }

        public ConfigItem()
        {
            this.Flag = FileRecognization.Unknown;
            this.ConfigFlag = ConfigMode.None;
            this.UOPositions = new List<ushort>();
        }

        public ConfigItem(Bitmap aUOBitmap, FileRecognization aFlag, ConfigMode aConfigFlag, List<ushort> aUOPositions)
        {
            this.UOBitmap = new Bitmap(aUOBitmap);
            this.Flag = aFlag;
            this.ConfigFlag = aConfigFlag;
            this.UOPositions = new List<ushort>();
            foreach (ushort lValue in aUOPositions)
                this.UOPositions.Add(lValue);
        }

        public ConfigItem(ConfigItem aConfItem)
        {
            this.UOBitmap = new Bitmap(aConfItem.UOBitmap);
            this.Flag = aConfItem.Flag;
            this.ConfigFlag = aConfItem.ConfigFlag;
            this.UOPositions = new List<ushort>();
            foreach (ushort lValue in aConfItem.UOPositions)
                this.UOPositions.Add(lValue);
        }

        public void Clear()
        {
            this.UOBitmap = null;
            this.Flag = FileRecognization.Unknown;
            this.ConfigFlag = ConfigMode.None;
            this.UOPositions = null;
        }

    }


}
