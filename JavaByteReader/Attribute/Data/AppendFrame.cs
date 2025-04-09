namespace JavaByteReader.Attribute.Data;

struct AppendFrame {
    public ushort offsetDelta;
    public VerificationTypeInfo[] locals;

    public AppendFrame(ushort offsetDelta, VerificationTypeInfo[] locals) {
        this.offsetDelta = offsetDelta;
        this.locals = locals;
    }

    public AppendFrame(FixedBinaryReader reader, byte frameType) {
        offsetDelta = reader.ReadUInt16();
        locals = new VerificationTypeInfo[frameType - 251];
        for(int i = 0; i < locals.Length; i++) locals[i] = new VerificationTypeInfo(reader);
    }
}