namespace JavaByteReader.Attribute.Data;

struct AppendFrame {
    // 252-254: append frame
    public byte frameType;
    public ushort offsetDelta;
    public VerificationTypeInfo[] locals;

    public AppendFrame(byte frameType, ushort offsetDelta, VerificationTypeInfo[] locals) {
        this.frameType = frameType;
        this.offsetDelta = offsetDelta;
        this.locals = locals;
    }

    public AppendFrame(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        offsetDelta = reader.ReadUInt16();
        locals = new VerificationTypeInfo[frameType - 251];
        for(int i = 0; i < locals.Length; i++) locals[i] = new VerificationTypeInfo(reader);
    }
}