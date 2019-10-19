using LegacyMUL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultima;

namespace VMulPatcher
{
    public class Program
    {
        private static List<Item> FItems = new List<Item>();

        private static string FArtPath = "Arts";
        private static string FGumpPath = "Gumps";
        private static string FTexturePath = "Textures";

        private static string FArtConfig = "ArtsConfig.ini";
        private static string FGumpConfig = "GumpsConfig.ini";
        private static string FTextureConfig = "TexturesConfig.ini";

        private static bool FIsPatch = false;
        private static string FPatchFileName;

        [STAThread]
        public static void Main(string[] args)
        {
            DateTime lTimer = new DateTime();

            if (args.Length > 0)
            {
                FIsPatch = true;
                FPatchFileName = args[0];
            }

            Console.Title = "Venushja Mulpatcher v0.2 aplha";
            if (!FIsPatch)
            {
                Console.WriteLine("0 for GUI (correctly works only on x64 app)");
                Console.WriteLine("1 for Arts - 11 for Arts [.uop]");
                Console.WriteLine("2 for Gumps - 22 for Gumps [.uop]");
                Console.WriteLine("3 for Textures");
                string lValue = Console.ReadLine();
                lValue = lValue.Trim();

                int lChoose = Convert.ToInt32(lValue);

                Console.WriteLine("Loading mul files");
                Files.LoadMulPath();
                Console.WriteLine("Loaded mul files");

                switch (lChoose)
                {
                    case 0:
                        Console.WriteLine("Choosed GUI...");
                        RunGUI();
                        Console.ReadKey();
                        break;
                    case 1:
                    case 11:
                        Console.WriteLine("Choosed ART...");
                        Utility.LoadConfig(FArtConfig, ref FItems);
                        Utility.LoadPath(FileRecognization.Art, ref FItems, FArtPath);
                        if (lChoose == 11)
                        {
                            Console.WriteLine("Unpacking .uop");
                            Utility.UnpackUOP(FileType.ArtLegacyMUL);
                            Console.WriteLine("Unpacked!");
                            Art.Reload();
                        }
                        PatchArt();
                        break;

                    case 2:
                    case 22:
                        Console.WriteLine("Choosed GUMP...");
                        Utility.LoadConfig(FGumpConfig, ref FItems);
                        Utility.LoadPath(FileRecognization.Gump, ref FItems, FGumpPath);
                        if (lChoose == 22)
                        {
                            Console.WriteLine("Unpacking .uop");
                            Utility.UnpackUOP(FileType.GumpartLegacyMUL);
                            Console.WriteLine("Unpacked!");
                            Gumps.Reload();
                        }
                        PatchGump();
                        break;

                    case 3:
                        Console.WriteLine("Choosed TEXTURE...");
                        Utility.LoadConfig(FTextureConfig, ref FItems);
                        Utility.LoadPath(FileRecognization.Texture, ref FItems, FTexturePath);
                        PatchTexture();
                        break;
                    case 666:
                        Application.EnableVisualStyles();
                        Application.Run(new DebugForm(0));
                        Console.ReadKey();
                        break;
                    case 6666:
                        Bitmap original;
                        ushort[] Items = new ushort[] { 0x0D85, 0x0CC7, 0x134F };
                        string[] Names = new string[] { "parez", "prazdne", "kameny" };
                        for (int y = 0; y < Items.Length; y++)
                        {
                            Console.WriteLine(Names[y] + " creating...");
                            StreamWriter lSW = new StreamWriter(Names[y] + ".txt");
                            lSW.Write(Names[y] + " = { ");
                            for (ushort i = 0; i < Art.GetMaxItemID(); i++)
                            {
                                Bitmap next = Art.GetStaticNoCache(i);
                                original = Art.GetStaticNoCache(Items[y]); //0x0D85, 0x0CC7
                                try
                                {
                                    if (BitmapComparer.CompareBitmapsFast(original, next))
                                    {
                                        Console.WriteLine("Positon 0x" + i.ToString("X4") + " is same. Added");
                                        //lSW.WriteLine("0x" + i.ToString("X4"));
                                        lSW.Write("0x" + i.ToString("X4") + ", ");
                                    }
                                }
                                finally
                                {
                                    next = null;
                                }
                            }
                            lSW.Write("}");
                            lSW.Close();
                        }
                        break;
                }
                lTimer = DateTime.Now;
                Save(lChoose);
            }
            else
            {
                Console.WriteLine("0 for patch into MUL files");
                Console.WriteLine("1 for patch into UOP files");
                string lValue = Console.ReadLine();
                lValue = lValue.Trim();

                int lChoose = Convert.ToInt32(lValue);

                Console.WriteLine("Loading mul files");
                Files.LoadMulPath();
                Console.WriteLine("Loaded mul files");

                PatchesUtility lPatchesUtility = new PatchesUtility(FPatchFileName);

                if (lChoose == 1)
                {
                    bool lArtsUnpacked = false;
                    foreach (FileRecognization lFileRec in lPatchesUtility.ContainsFlags)
                    {
                        switch (lFileRec)
                        {
                            case FileRecognization.Art: case FileRecognization.ArtLand:
                                if (lArtsUnpacked)
                                    continue;
                                Console.WriteLine("Unpacking arts .uop file");
                                Utility.UnpackUOP(FileType.ArtLegacyMUL);
                                Console.WriteLine("Unpacked!");
                                Art.Reload();
                                lArtsUnpacked = true;
                                break;

                            case FileRecognization.Gump:
                                Console.WriteLine("Unpacking gumps .uop file");
                                Utility.UnpackUOP(FileType.GumpartLegacyMUL);
                                Console.WriteLine("Unpacked!");
                                Gumps.Reload();
                                break;
                        }
                    }
                }
                PatchDragAndDropPatch(ref lPatchesUtility.FVMulPatches);

                lTimer = DateTime.Now;
                Save(ref lPatchesUtility.ContainsFlags, lChoose == 1);
            }
            Console.WriteLine("Time elapsed: " + Math.Round(Convert.ToDecimal((DateTime.Now - lTimer).TotalMinutes), 4) + " minutes");
            Console.ReadKey();
        }

        public static void PatchArt()
        {
            Console.WriteLine("Patching Arts...");
            foreach (Item lItem in FItems)
            {
                Bitmap lImage = new Bitmap(lItem.FilePath);
                lImage.MakeTransparent(lImage.GetPixel(1, 1));
                foreach (ushort lPosition in lItem.Positions)
                {
                    int lPosIndex = (int)lPosition;
                    if (lItem.Flag == FileRecognization.ArtLand)
                        Art.ReplaceLand(lPosIndex, lImage);
                    else
                        Art.ReplaceStatic(lPosIndex, lImage);
                    Console.WriteLine(" -> Replaced [" + (lItem.Flag == FileRecognization.ArtLand ? "Land" : "Art") + "] position: 0x" + lPosIndex.ToString("X4"));
                }
            }
            Console.WriteLine("Patching Arts done...");
        }

        public static void PatchGump()
        {
            Console.WriteLine("Patching Gumps...");
            foreach (Item lItem in FItems)
            {
                Bitmap lImage = new Bitmap(lItem.FilePath);
                lImage.MakeTransparent(lImage.GetPixel(1, 1));
                foreach (ushort lPosition in lItem.Positions)
                {
                    int lPosIndex = (int)lPosition;
                    Gumps.ReplaceGump(lPosIndex, lImage);
                    Console.WriteLine(" -> Replaced [Gump] position: 0x" + lPosIndex.ToString("X4"));
                }
            }
            Console.WriteLine("Patching Gumps done...");
        }

        public static void PatchTexture()
        {
            Console.WriteLine("Patching Textures...");
            foreach (Item lItem in FItems)
            {
                Bitmap lImage = new Bitmap(lItem.FilePath);
                lImage.MakeTransparent(lImage.GetPixel(1, 1));
                foreach (ushort lPosition in lItem.Positions)
                {
                    int lPosIndex = (int)lPosition;
                    Textures.Replace(lPosIndex, lImage);
                    Console.WriteLine(" -> Replaced [Texture] position: 0x" + lPosIndex.ToString("X4"));
                }
            }
            Console.WriteLine("Patching Textures done...");
        }

        public static void PatchDragAndDropPatch(ref List<VMulPatch> aItems)
        {
            Console.WriteLine("Patching loaded patch...");

            foreach (VMulPatch lItem in aItems)
            {
                Bitmap lImage = new Bitmap(lItem.UOBitmap);
                lImage.MakeTransparent(lImage.GetPixel(1, 1));

                FileRecognization lFileRec = (FileRecognization)lItem.PatchHeader.Flag;

                foreach(ushort lPosition in lItem.FilePositions)
                {
                    int lPosIndex = (int)lPosition;
                    switch(lFileRec)
                    {
                        case FileRecognization.Art:
                            Art.ReplaceStatic(lPosIndex, lImage);
                            Console.WriteLine(" -> Replaced [Art] position: 0x" + lPosIndex.ToString("X4"));
                            break;
                            
                        case FileRecognization.ArtLand:
                            Art.ReplaceLand(lPosIndex, lImage);
                            Console.WriteLine(" -> Replaced [Land] position: 0x" + lPosIndex.ToString("X4"));
                            break;

                        case FileRecognization.Gump:
                            Gumps.ReplaceGump(lPosIndex, lImage);
                            Console.WriteLine(" -> Replaced [Gump] position: 0x" + lPosIndex.ToString("X4"));
                            break;

                        case FileRecognization.Texture:
                            Textures.Replace(lPosIndex, lImage);
                            Console.WriteLine(" -> Replaced [Texture] position: 0x" + lPosIndex.ToString("X4"));
                            break;
                    }
                }
            }
            Console.WriteLine("Patching loaded patch done...");
        }

        public static void Save(int aChoose)
        {
            Console.WriteLine("Saving .mul files");
            if (!Directory.Exists("Patched"))
                Directory.CreateDirectory("Patched");
            switch (aChoose)
            {
                case 1: case 11:
                    Art.Save("Patched");
                    break;

                case 2: case 22:
                    Gumps.Save("Patched");
                    break;

                case 3:
                    Textures.Save("Patched");
                    break;
            }
            Console.WriteLine("MUL files saved!");

            if (aChoose == 11 || aChoose == 22)
            {
                Console.WriteLine("Packing to .uop");
                if (aChoose == 11)
                    Utility.PackUOP(FileType.ArtLegacyMUL);
                else if (aChoose == 22)
                    Utility.PackUOP(FileType.GumpartLegacyMUL);
                Console.WriteLine("Packed!");
            }
            Console.WriteLine("Patched files find in 'Patched' directory...");
        }

        public static void Save(ref List<FileRecognization> aFileRec, bool aToUOP)
        {
            Console.WriteLine("Saving .mul files");
            if (!Directory.Exists("Patched"))
                Directory.CreateDirectory("Patched");
            
            bool lArtsPacked = false;
            foreach(FileRecognization lValue in aFileRec)
            {
                switch (lValue)
                {
                    case FileRecognization.Art: case FileRecognization.ArtLand:
                        if (lArtsPacked)
                            continue;
                        Art.Save("Patched");
                        lArtsPacked = true;
                        Console.WriteLine("MUL file of Arts saved!");
                        if (aToUOP)
                        {
                            Console.Write("UOP file of Arts packing...");
                            Utility.PackUOP(FileType.ArtLegacyMUL);
                            Console.WriteLine("UOP file of Arts created!");
                        }
                        break;

                    case FileRecognization.Gump:
                        Gumps.Save("Patched");
                        Console.WriteLine("MUL file of Gumps saved!");
                        if (aToUOP)
                        {
                            Console.Write("UOP file of Gumps packing...");
                            Utility.PackUOP(FileType.GumpartLegacyMUL);
                            Console.WriteLine("UOP file of Gumps created!");
                        }
                        break;

                    case FileRecognization.Texture:
                        Textures.Save("Packed");
                        Console.WriteLine("MUL file of Textures saved!");
                        break;
                }
            }
            Console.WriteLine("Patched files find in 'Patched' directory...");
        }

        public static void RunGUI()
        {
            Application.EnableVisualStyles();
            MainForm lFrm = new MainForm();
            lFrm.ShowDialog();
        }
    }
}
