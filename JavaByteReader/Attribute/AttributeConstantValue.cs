namespace JavaByteReader.Attribute;

class AttributeConstantValue : JavaAttribute {
    public const string AttributeName = "ConstantValue";
    public ushort valueIndex;

    public AttributeConstantValue(ushort valueIndex) {
        this.valueIndex = valueIndex;
    }

    internal AttributeConstantValue(FixedBinaryReader reader) {
        valueIndex = reader.ReadUInt16();
    }

    public override string Name => AttributeName;
}