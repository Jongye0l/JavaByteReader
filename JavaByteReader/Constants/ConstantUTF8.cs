using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JavaByteReader.Constants;

class ConstantUTF8 : Constant {

    public override byte TagCode => 1;
    public string data;

    public override void Read(FixedBinaryReader reader) {
        ushort length = reader.ReadUInt16();
        data = Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    public override void SetupValue(Constant[] constants) { }
}