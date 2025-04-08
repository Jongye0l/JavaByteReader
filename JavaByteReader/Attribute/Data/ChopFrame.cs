namespace JavaByteReader.Attribute.Data;

struct ChopFrame {
    // 248-250: chop frame
    public byte frameType;
    public ushort offsetDelta;

    public ChopFrame(byte frameType, ushort offsetDelta) {
        this.frameType = frameType;
        this.offsetDelta = offsetDelta;
    }

    public ChopFrame(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        offsetDelta = reader.ReadUInt16();
    }
}