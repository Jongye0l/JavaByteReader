namespace JavaByteReader.Attribute.Data;

struct VerificationTypeInfo {
    public VariableInfoTag tag;
    // ITEM_Object: cpool index
    // ITEM_Uninitialized: offset
    public ushort subData;

    public VerificationTypeInfo(FixedBinaryReader reader) {
        tag = (VariableInfoTag) reader.ReadByte();
        if(tag is VariableInfoTag.ITEM_Object or VariableInfoTag.ITEM_Uninitialized) subData = reader.ReadUInt16();
    }

    public VerificationTypeInfo(VariableInfoTag tag, ushort subData) {
        this.tag = tag;
        this.subData = subData;
    }

    public VerificationTypeInfo(VariableInfoTag tag) {
        this.tag = tag;
    }
}