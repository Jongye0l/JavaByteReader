namespace JavaByteReader.Attribute;

class AttributeEnclosingMethod : JavaAttribute {
    public const string AttributeName = "EnclosingMethod";
    public ushort classIndex;
    public ushort methodIndex;

    public AttributeEnclosingMethod(ushort classIndex, ushort methodIndex) {
        this.classIndex = classIndex;
        this.methodIndex = methodIndex;
    }

    public AttributeEnclosingMethod(FixedBinaryReader reader) {
        classIndex = reader.ReadUInt16();
        methodIndex = reader.ReadUInt16();
    }

    public override string Name => AttributeName;
}