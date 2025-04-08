namespace JavaByteReader.Attribute.Data;

struct EnumConstValue {
    public ushort typeNameIndex;
    public ushort constNameIndex;

    public EnumConstValue(ushort typeNameIndex, ushort constNameIndex) {
        this.typeNameIndex = typeNameIndex;
        this.constNameIndex = constNameIndex;
    }

    public EnumConstValue(FixedBinaryReader reader) {
        typeNameIndex = reader.ReadUInt16();
        constNameIndex = reader.ReadUInt16();
    }
}