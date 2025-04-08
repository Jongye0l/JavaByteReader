namespace JavaByteReader.Attribute.Data;

struct FullFrame {
    // 255: full frame
    public byte frameType;
    public ushort offsetDelta;
    public VerificationTypeInfo[] locals;
    public VerificationTypeInfo[] stack;

    public FullFrame(byte frameType, ushort offsetDelta, VerificationTypeInfo[] locals, VerificationTypeInfo[] stack) {
        this.frameType = frameType;
        this.offsetDelta = offsetDelta;
        this.locals = locals;
        this.stack = stack;
    }

    public FullFrame(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        offsetDelta = reader.ReadUInt16();
        locals = new VerificationTypeInfo[reader.ReadUInt16()];
        for(int i = 0; i < locals.Length; i++) locals[i] = new VerificationTypeInfo(reader);
        stack = new VerificationTypeInfo[reader.ReadUInt16()];
        for(int i = 0; i < stack.Length; i++) stack[i] = new VerificationTypeInfo(reader);
    }
}