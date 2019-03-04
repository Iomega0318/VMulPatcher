using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMulPatcher
{
    public class PatchHeader
    {
        public byte Flag;
        public byte ConfigFlag;
        public ushort PositionCount;
        public int UOBitmapSize;
    }

    public class VMulPatch
    {
        public PatchHeader PatchHeader { get; set; }
        public List<ushort> FilePositions { get; set; }
        public Bitmap UOBitmap { get; set; }

        public VMulPatch()
        {
            this.PatchHeader = new PatchHeader();
            this.FilePositions = new List<ushort>();
        }
    }

    public class PatchesUtility
    {
        public List<VMulPatch> FVMulPatches;
        public List<FileRecognization> ContainsFlags;

        public PatchesUtility(string aFilename)
        {
            FVMulPatches = new List<VMulPatch>();
            this.ContainsFlags = new List<FileRecognization>();
            this.LoadVMulPatch(aFilename);
        }

        public void LoadVMulPatch(string aFilename)
        {
            Console.WriteLine("Loading patch " + Path.GetFileName(aFilename));
            BinaryReader lBinReader = new BinaryReader(File.Open(aFilename, FileMode.Open));

            lBinReader.BaseStream.Position = 0;
            while (lBinReader.BaseStream.Position != lBinReader.BaseStream.Length)
            {
                VMulPatch lPatch = new VMulPatch();
                lPatch.PatchHeader.Flag = lBinReader.ReadByte();
                lPatch.PatchHeader.ConfigFlag = lBinReader.ReadByte();
                lPatch.PatchHeader.PositionCount = lBinReader.ReadUInt16();
                lPatch.PatchHeader.UOBitmapSize = lBinReader.ReadInt32();

                for (int i = 0; i < lPatch.PatchHeader.PositionCount; i++)
                    lPatch.FilePositions.Add(lBinReader.ReadUInt16());

                byte[] lBitmapBytes = lBinReader.ReadBytes(lPatch.PatchHeader.UOBitmapSize);
                MemoryStream lBitmapMS = new MemoryStream(lBitmapBytes);
                lPatch.UOBitmap = new Bitmap(lBitmapMS);

                FileRecognization lFileRec = (FileRecognization)lPatch.PatchHeader.Flag;
                if (!this.ContainsFlags.Contains(lFileRec))
                    this.ContainsFlags.Add(lFileRec);

                FVMulPatches.Add(lPatch);
            }
            Console.WriteLine("Patch loaded...");
            Console.WriteLine("Patch contains:");
            foreach (FileRecognization lValue in this.ContainsFlags)
                Console.WriteLine(lValue.ToString() + " file format.");
            Console.WriteLine(FVMulPatches.Count() + " bitmaps to patch.");
        }
    }
}
