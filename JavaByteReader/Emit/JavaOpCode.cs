namespace JavaByteReader.Emit;

public sealed class JavaOpCode {
    public readonly string name;
    public readonly JavaCode code;
    public readonly byte instructionSize;
    public readonly byte getStackSize;
    public readonly byte setStackSize;

    public JavaOpCode(string name, JavaCode code) {
        this.name = name;
        this.code = code;
        JavaOpCodes.OpCodes[(int)code] = this;
    }

    public JavaOpCode(string name, JavaCode code, byte instructionSize, byte getStackSize, byte setStackSize) : this(name, code) {
        this.instructionSize = instructionSize;
        this.getStackSize = getStackSize;
        this.setStackSize = setStackSize;
    }
}