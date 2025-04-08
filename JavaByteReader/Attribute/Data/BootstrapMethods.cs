namespace JavaByteReader.Attribute.Data;

struct BootstrapMethods {
    public ushort bootstrapMethodRef;
    public ushort[] bootstrapArguments;

    public BootstrapMethods(ushort bootstrapMethodRef, ushort[] bootstrapArguments) {
        this.bootstrapMethodRef = bootstrapMethodRef;
        this.bootstrapArguments = bootstrapArguments;
    }

    public BootstrapMethods(FixedBinaryReader reader) {
        bootstrapMethodRef = reader.ReadUInt16();
        ushort numBootstrapArguments = reader.ReadUInt16();
        bootstrapArguments = new ushort[numBootstrapArguments];
        for(int i = 0; i < numBootstrapArguments; i++) bootstrapArguments[i] = reader.ReadUInt16();
    }
}