using System;
using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantMethodHandle : Constant {

    public override byte TagCode => 15;
    public byte referenceKind;
    public ushort referenceIndex;

    public override void Read(FixedBinaryReader reader) {
        referenceKind = reader.ReadByte();
        referenceIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        Console.WriteLine("ConstantMethodHandle: " + constants[referenceIndex]);
    }
}