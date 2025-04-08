using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantLong : Constant {

    public override byte TagCode => 5;
    public long data;

    public override void Read(FixedBinaryReader reader) {
        data = reader.ReadInt64();
    }

    public override void SetupValue(Constant[] constants) { }
}