namespace JavaByteReader;

public struct ClassVersion {
    public ushort majorVersion;
    public ushort minorVersion;

    public ClassVersion(ushort majorVersion, ushort minorVersion) {
        this.majorVersion = majorVersion;
        this.minorVersion = minorVersion;
    }

    public ClassVersion(FixedBinaryReader reader) {
        majorVersion = reader.ReadUInt16();
        minorVersion = reader.ReadUInt16();
    }

    public override string ToString() {
        return $"{majorVersion}.{minorVersion}";
    }
}