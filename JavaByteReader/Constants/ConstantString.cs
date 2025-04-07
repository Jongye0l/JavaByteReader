using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantString : Constant {
    public override byte TagCode => 8;
    public ushort StringIndex;
    public UTF8String String;

    public override void Read(BinaryReader reader) {
        StringIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        String = ((ConstantUTF8) constants[StringIndex]).data;
    }
}