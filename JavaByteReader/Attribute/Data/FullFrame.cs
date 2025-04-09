namespace JavaByteReader.Attribute.Data;

struct FullFrame {
    public ushort offsetDelta;
    public VerificationTypeInfo[] locals;
    public VerificationTypeInfo[] stack;

    public FullFrame(ushort offsetDelta, VerificationTypeInfo[] locals, VerificationTypeInfo[] stack) {
        this.offsetDelta = offsetDelta;
        this.locals = locals;
        this.stack = stack;
    }

    public FullFrame(FixedBinaryReader reader) {
        offsetDelta = reader.ReadUInt16();
        locals = new VerificationTypeInfo[reader.ReadUInt16()];
        for(int i = 0; i < locals.Length; i++) locals[i] = new VerificationTypeInfo(reader);
        stack = new VerificationTypeInfo[reader.ReadUInt16()];
        for(int i = 0; i < stack.Length; i++) stack[i] = new VerificationTypeInfo(reader);
    }
}