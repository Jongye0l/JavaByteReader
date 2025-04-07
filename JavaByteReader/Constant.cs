namespace JavaByteReader;

abstract class Constant {
    public abstract byte TagCode { get; }

    public abstract void Read(BinaryReader reader);

    public abstract void SetupValue(Constant[] constants);
}