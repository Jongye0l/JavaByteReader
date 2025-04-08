namespace JavaByteReader.Attribute;

class AttributeSourceFile : JavaAttribute {
    public const string AttributeName = "SourceFile";
    public ushort sourceFileIndex;

    public AttributeSourceFile(ushort sourceFileIndex) {
        this.sourceFileIndex = sourceFileIndex;
    }

    public AttributeSourceFile(FixedBinaryReader reader) {
        sourceFileIndex = reader.ReadUInt16();
    }

    public override string Name => AttributeName;
}