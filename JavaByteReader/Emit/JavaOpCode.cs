namespace JavaByteReader.Emit;

public sealed class JavaOpCode {
    public readonly string Name;
    public readonly JavaCode Code;

    public JavaOpCode(string name, JavaCode code) {
        Name = name;
        Code = code;
        JavaOpCodes.OpCodes[(int)code] = this;
    }
}