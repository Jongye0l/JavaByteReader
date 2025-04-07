using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantDouble : Constant {

    public override byte TagCode => 6;
    public double data;

    public override void Read(BinaryReader reader) {
        data = reader.ReadDouble();
    }

    public override void SetupValue(Constant[] constants) { }
}