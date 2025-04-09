using System.IO;

namespace JavaByteReader.Attribute.Data;

struct StackMapFrame {
    public byte frameType;
    public object frameData;

    public StackMapFrame(byte frameType, object frameData) {
        this.frameType = frameType;
        this.frameData = frameData;
    }

    public StackMapFrame(FixedBinaryReader reader) {
        frameType = reader.ReadByte();
        frameData = frameType switch {
            < 64 => null, // SameFrame
            < 128 => new VerificationTypeInfo(reader), // SameLocals1StackItemFrame
            < 247 => throw new InvalidDataException("Invalid frame type: " + frameType),
            247 => new SameLocals1StackItemFrameExtended(reader), // SameLocals1StackItemFrameExtended
            <= 251 => reader.ReadUInt16(), // ChopFrame, SameFrameExtended - offsetDelta
            < 255 => new AppendFrame(reader, frameType), // AppendFrame
            _ => new FullFrame(reader) // FullFrame
        };
    }
}