using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantFloat : Constant {

    public override byte TagCode => 4;
    public float data;

    public override void Read(BinaryReader reader) {
        data = reader.ReadSingle();
    }

    public override void SetupValue(Constant[] constants) { }
}