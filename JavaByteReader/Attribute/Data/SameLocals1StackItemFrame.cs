namespace JavaByteReader.Attribute.Data;

struct SameLocals1StackItemFrame {
    // 64-127: same locals + 1 stack item
    public byte frameType;
    public VerificationTypeInfo stack;

    public SameLocals1StackItemFrame(byte frameType, VerificationTypeInfo stack) {
        this.frameType = frameType;
        this.stack = stack;
    }

    public SameLocals1StackItemFrame(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        stack = new VerificationTypeInfo(reader);
    }
}