using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeStackMapTable : JavaAttribute {
    public const string AttributeName = "StackMapTable";

    public StackMapFrame[] entries;

    public AttributeStackMapTable(StackMapFrame[] entries) {
        this.entries = entries;
    }

    public AttributeStackMapTable(FixedBinaryReader reader) {
        entries = new StackMapFrame[reader.ReadUInt16()];
        for(int i = 0; i < entries.Length; i++) entries[i] = new StackMapFrame(reader);
    }

    public override string Name => AttributeName;
}