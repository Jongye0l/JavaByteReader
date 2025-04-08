namespace JavaByteReader.Attribute.Data;

struct SameLocals1StackItemFrameExtended {
    // 247: same locals + 1 stack item extended
    public byte frameType;
    public ushort offsetDelta;
    public VerificationTypeInfo stack;

    public SameLocals1StackItemFrameExtended(byte frameType, ushort offsetDelta, VerificationTypeInfo stack) {
        this.frameType = frameType;
        this.offsetDelta = offsetDelta;
        this.stack = stack;
    }

    public SameLocals1StackItemFrameExtended(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        offsetDelta = reader.ReadUInt16();
        stack = new VerificationTypeInfo(reader);
    }
}