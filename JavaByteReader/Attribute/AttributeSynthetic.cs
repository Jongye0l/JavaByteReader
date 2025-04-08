namespace JavaByteReader.Attribute;

class AttributeSynthetic : JavaAttribute {
    public const string AttributeName = "Synthetic";
    public override string Name => AttributeName;
}