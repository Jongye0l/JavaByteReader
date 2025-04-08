using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantMethodType : Constant {

    public override byte TagCode => 16;
    public ushort descriptorIndex;
    public string descriptor;

    public override void Read(FixedBinaryReader reader) {
        descriptorIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        descriptor = ((ConstantUTF8) constants[descriptorIndex]).data;
    }
}