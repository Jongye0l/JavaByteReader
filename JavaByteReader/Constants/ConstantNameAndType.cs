namespace JavaByteReader.Constants;

class ConstantNameAndType : Constant {

    public override byte TagCode => 12;
    public ushort nameIndex;
    public ushort descriptorIndex;
    public string name;
    public string descriptor;

    public override void Read(FixedBinaryReader reader) {
        nameIndex = reader.ReadUInt16();
        descriptorIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        name = ((ConstantUTF8) constants[nameIndex]).data;
        descriptor = ((ConstantUTF8) constants[descriptorIndex]).data;
    }
}