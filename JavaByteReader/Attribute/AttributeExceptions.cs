namespace JavaByteReader.Attribute;

class AttributeExceptions : JavaAttribute {
    public const string AttributeName = "Exceptions";

    public ushort[] exceptionIndexTable;

    public AttributeExceptions(ushort[] exceptionIndexTable) {
        this.exceptionIndexTable = exceptionIndexTable;
    }

    public AttributeExceptions(FixedBinaryReader reader) {
        exceptionIndexTable = new ushort[reader.ReadUInt16()];
        for(int i = 0; i < exceptionIndexTable.Length; i++) exceptionIndexTable[i] = reader.ReadUInt16();
    }

    public override string Name => AttributeName;
}