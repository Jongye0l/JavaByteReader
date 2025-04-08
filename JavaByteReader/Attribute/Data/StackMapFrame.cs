namespace JavaByteReader.Attribute.Data;

// TODO: Setup Union
struct StackMapFrame {
    public SameFrame sameFrame;
    public SameLocals1StackItemFrame sameLocals1StackItemFrame;
    public SameLocals1StackItemFrameExtended sameLocals1StackItemFrameExtended;
    public ChopFrame chopFrame;
    public SameFrameExtended sameFrameExtended;
    public AppendFrame appendFrame;
    public FullFrame fullFrame;

    public StackMapFrame(FixedBinaryReader reader) {
        sameFrame.frameType = reader.ReadByte();
        sameLocals1StackItemFrame = new SameLocals1StackItemFrame(reader);
        sameLocals1StackItemFrameExtended = new SameLocals1StackItemFrameExtended(reader);
        chopFrame = new ChopFrame(reader);
        sameFrameExtended = new SameFrameExtended(reader);
        appendFrame = new AppendFrame(reader);
        fullFrame = new FullFrame(reader);
    }
}