using JavaByteReader.Attribute.Data;

namespace JavaByteReader.Attribute;

class AttributeBootstrapMethods : JavaAttribute {
    public const string AttributeName = "BootstrapMethods";
    public BootstrapMethods[] bootstrapMethods;

    public AttributeBootstrapMethods(BootstrapMethods[] bootstrapMethods) {
        this.bootstrapMethods = bootstrapMethods;
    }

    public AttributeBootstrapMethods(FixedBinaryReader reader) {
        ushort numBootstrapMethods = reader.ReadUInt16();
        bootstrapMethods = new BootstrapMethods[numBootstrapMethods];
        for(int i = 0; i < numBootstrapMethods; i++) bootstrapMethods[i] = new BootstrapMethods(reader);
    }

    public override string Name => AttributeName;
}