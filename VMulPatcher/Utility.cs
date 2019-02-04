using LegacyMUL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMulPatcher
{
    public sealed class Utility
    {
        public static void LoadConfig(string aConfigFile, ref List<Item> aItems)
        {
            Console.WriteLine("Loading config file...");

            StreamReader lRead = new StreamReader(aConfigFile);

            aItems.Clear();

            string lLine;

            while ((lLine = lRead.ReadLine()) != null)
            {
                lLine = lLine.Trim();
                if ((lLine == null || lLine.Length == 0) || lLine[0] == '#')
                    continue;

                if (lLine != null && lLine.Length > 0)
                {
                    string[] lLineSplit = lLine.Split('=');
                    string lKey = lLineSplit[0].Trim();
                    string lValue = lLineSplit[1].Trim();

                    List<ushort> lValues = new List<ushort>();
                    if (lValue.Contains("[") && lValue.Contains("]")) // Range [ ]
                    {
                        lValue = lValue.Replace('[', ' ').Replace(']', ' ');
                        string[] lValuesSplit = lValue.Split(',');
                        for (int i = 0; i < lValuesSplit.Length; i++)
                        {
                            string[] lRangedValue = lValuesSplit[i].Split('-');
                            lRangedValue[0] = lRangedValue[0].Trim();
                            lRangedValue[0] = lRangedValue[0].Remove(0, 2);
                            lRangedValue[1] = lRangedValue[1].Trim();
                            lRangedValue[1] = lRangedValue[1].Remove(0, 2);
                            ushort lConvertedValueFirst = ushort.Parse(lRangedValue[0], System.Globalization.NumberStyles.AllowHexSpecifier);
                            ushort lConvertedValueSecond = ushort.Parse(lRangedValue[1], System.Globalization.NumberStyles.AllowHexSpecifier);
                            for (ushort y = lConvertedValueFirst; y <= lConvertedValueSecond; y++)
                                lValues.Add(y);
                        }
                    }
                    else if (lValue.Contains("{") && lValue.Contains("}")) // Range { }
                    {
                        lValue = lValue.Replace('{', ' ').Replace('}', ' ');
                        string[] lValuesSplit = lValue.Split(',');
                        for (int i = 0; i < lValuesSplit.Length; i++)
                        {
                            lValuesSplit[i] = lValuesSplit[i].Trim();
                            lValuesSplit[i] = lValuesSplit[i].Remove(0, 2);
                            ushort lConvertedValue = ushort.Parse(lValuesSplit[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                            lValues.Add(lConvertedValue);
                        }
                    }
                    else
                    {
                        lValue = lValue.Trim();
                        lValue = lValue.Remove(0, 2);
                        ushort lConvertedValue = ushort.Parse(lValue, System.Globalization.NumberStyles.AllowHexSpecifier);
                        lValues.Add(lConvertedValue);
                    }

                    IEnumerable<Item> lExistItem = aItems.Where(x => x.BitmapName == lKey);
                    if (lExistItem != null && lExistItem.Count() > 0)
                    {
                        Item lSelItem = lExistItem.First();
                        lSelItem.Positions.AddRange(lValues);
                    }
                    else
                    {
                        Item lNewItem = new Item(lKey, lValues);
                        aItems.Add(lNewItem);
                    }
                }
            }
            Console.WriteLine("Loaded config file...");
        }

        public static void LoadPath(FileRecognization aFileRecognization, ref List<Item> aItems, string aFolderPath)
        {
            switch(aFileRecognization)
            {
                case FileRecognization.Art:
                    Console.WriteLine("Loading images in Arts folder...");
                    break;
                case FileRecognization.Gump:
                    Console.WriteLine("Loading images in Gumps folder...");
                    break;
                case FileRecognization.Texture:
                    Console.WriteLine("Loading images in Textures folder...");
                    break;
            }
            int lCounter = 0;
            foreach (string lFilePath in Directory.GetFiles(aFolderPath, "*.bmp", SearchOption.AllDirectories))
            {
                IEnumerable<Item> lItem = aItems.Where(x => x.BitmapName + ".bmp" == Path.GetFileName(lFilePath));
                if (lItem != null && lItem.Count() > 0)
                {
                    Item lFoundItem = lItem.First();

                    if (aFileRecognization == FileRecognization.Art)
                    {
                        if (lFoundItem.Flag == FileRecognization.Unknown)
                        {
                            if (lFilePath.Contains("Lands"))
                                lFoundItem.Flag = FileRecognization.ArtLand;
                            else
                                lFoundItem.Flag = FileRecognization.Art;
                        }
                    }
                    else if (aFileRecognization == FileRecognization.Gump)
                        lFoundItem.Flag = FileRecognization.Gump;
                    else if (aFileRecognization == FileRecognization.Texture)
                        lFoundItem.Flag = FileRecognization.Texture;

                    lFoundItem.FilePath = lFilePath;
                }
                else
                {
                    // check name of bitmap if bitmap name is hex number add as item...
                    string lFileName = Path.GetFileName(lFilePath);
                    string lFileNameSplited = lFileName.Split('.')[0];
                    lFileNameSplited = lFileNameSplited.Trim().Remove(0, 2);
                    ushort lValue;
                    if (ushort.TryParse(lFileNameSplited, System.Globalization.NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out lValue))
                    {
                        Item lNewItem = new Item(lFileName.Split('.')[0], new List<ushort>() { lValue });

                        if (aFileRecognization == FileRecognization.Art)
                        {
                            if (lFilePath.Contains("Lands"))
                                lNewItem.Flag = FileRecognization.ArtLand;
                            else
                                lNewItem.Flag = FileRecognization.Art;
                        }
                        else if (aFileRecognization == FileRecognization.Gump)
                            lNewItem.Flag = FileRecognization.Gump;
                        else if (lNewItem.Flag == FileRecognization.Texture)
                            lNewItem.Flag = FileRecognization.Texture;

                        lNewItem.FilePath = lFilePath;
                        aItems.Add(lNewItem);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" -> " + lFileName + " is not correct format or missing in config file.");
                        Console.ResetColor();
                        lCounter--;
                    }
                }
                lCounter++;
            }
            Console.WriteLine("Loaded " + lCounter.ToString() + " images...");
        }

        public static void UnpackUOP(FileType aFileType)
        {
            LegacyMULConverter lConverter = new LegacyMULConverter();
            string PathFiles = "MulFiles";

            switch (aFileType)
            {
                case FileType.ArtLegacyMUL:
                    lConverter.FromUOP(Path.Combine(PathFiles, "artLegacyMUL.uop"), Path.Combine(PathFiles, "art.mul"), Path.Combine(PathFiles, "artidx.mul"), aFileType, 0);
                    break;

                case FileType.GumpartLegacyMUL:
                    lConverter.FromUOP(Path.Combine(PathFiles, "gumpartLegacyMUL.uop"), Path.Combine(PathFiles, "gumpart.mul"), Path.Combine(PathFiles, "gumpidx.mul"), aFileType, 0);
                    break;
            }
        }

        public static void PackUOP(FileType aFileType)
        {
            LegacyMULConverter lConverter = new LegacyMULConverter();
            string PathDestination = "Patched";

            switch (aFileType)
            {
                case FileType.ArtLegacyMUL:
                    lConverter.ToUOP(Path.Combine(PathDestination, "art.mul"), Path.Combine(PathDestination, "artidx.mul"), Path.Combine(PathDestination, "artLegacyMUL.uop"), aFileType, 0);
                    break;

                case FileType.GumpartLegacyMUL:
                    lConverter.ToUOP(Path.Combine(PathDestination, "gumpart.mul"), Path.Combine(PathDestination, "gumpidx.mul"), Path.Combine(PathDestination, "gumpartLegacyMUL.uop"), aFileType, 0);
                    break;
            }
        }
    }
}
