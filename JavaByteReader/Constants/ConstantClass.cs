using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantClass : Constant {

    public override byte TagCode => 7;
    public ushort NameIndex;
    public UTF8String Name;

    public override void Read(FixedBinaryReader reader) {
        NameIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        Name = ((ConstantUTF8) constants[NameIndex]).data;
    }
}