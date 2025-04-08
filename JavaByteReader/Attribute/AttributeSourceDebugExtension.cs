namespace JavaByteReader.Attribute;

class AttributeSourceDebugExtension : JavaAttribute {
    public const string AttributeName = "SourceDebugExtension";
    public byte[] debugExtension;

    public AttributeSourceDebugExtension(byte[] debugExtension) {
        this.debugExtension = debugExtension;
    }

    public AttributeSourceDebugExtension(FixedBinaryReader reader, uint size) {
        debugExtension = new byte[size];
        for(int i = 0; i < size; i++) debugExtension[i] = reader.ReadByte();
    }

    public override string Name => AttributeName;
}