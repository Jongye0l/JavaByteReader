using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantUTF8 : Constant {

    public override byte TagCode => 1;
    public UTF8String data;

    public override void Read(BinaryReader reader) {
        ushort length = reader.ReadUInt16();
        byte[] bytes = reader.ReadBytes(length);
        data = new UTF8String(bytes);
    }

    public override void SetupValue(Constant[] constants) { }
}