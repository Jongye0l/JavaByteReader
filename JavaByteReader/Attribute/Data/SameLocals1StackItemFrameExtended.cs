namespace JavaByteReader.Attribute.Data;

struct SameLocals1StackItemFrameExtended {
    public ushort offsetDelta;
    public VerificationTypeInfo stack;

    public SameLocals1StackItemFrameExtended(ushort offsetDelta, VerificationTypeInfo stack) {
        this.offsetDelta = offsetDelta;
        this.stack = stack;
    }

    public SameLocals1StackItemFrameExtended(FixedBinaryReader reader) {
        offsetDelta = reader.ReadUInt16();
        stack = new VerificationTypeInfo(reader);
    }
}