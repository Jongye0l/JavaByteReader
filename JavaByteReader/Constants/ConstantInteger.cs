using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantInteger : Constant {

    public override byte TagCode => 3;
    public int data;

    public override void Read(BinaryReader reader) {
        data = reader.ReadInt32();
    }

    public override void SetupValue(Constant[] constants) { }
}