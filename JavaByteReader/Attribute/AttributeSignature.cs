namespace JavaByteReader.Attribute;

class AttributeSignature : JavaAttribute {
    public const string AttributeName = "Signature";
    public ushort signatureIndex;

    public AttributeSignature(ushort signatureIndex) {
        this.signatureIndex = signatureIndex;
    }

    public AttributeSignature(FixedBinaryReader reader) {
        signatureIndex = reader.ReadUInt16();
    }

    public override string Name => AttributeName;
}