namespace JavaByteReader.Attribute.Data;

public struct SameFrameExtended {
    // 251: same frame extended
    public byte frameType;
    public ushort offsetDelta;

    public SameFrameExtended(byte frameType, ushort offsetDelta) {
        this.frameType = frameType;
        this.offsetDelta = offsetDelta;
    }

    public SameFrameExtended(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        offsetDelta = reader.ReadUInt16();
    }
}