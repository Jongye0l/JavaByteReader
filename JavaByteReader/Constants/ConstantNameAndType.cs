using System.IO;

namespace JavaByteReader.Constants;

class ConstantNameAndType : Constant {

    public override byte TagCode => 12;
    public ushort nameIndex;
    public ushort descriptorIndex;
    public UTF8String name;
    public UTF8String descriptor;

    public override void Read(BinaryReader reader) {
        nameIndex = reader.ReadUInt16();
        descriptorIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        name = ((ConstantUTF8) constants[nameIndex]).data;
        descriptor = ((ConstantUTF8) constants[descriptorIndex]).data;
    }
}