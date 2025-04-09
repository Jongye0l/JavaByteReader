namespace JavaByteReader.Emit;

public class JavaOpCodes {
    public static readonly JavaOpCode[] OpCodes = new JavaOpCode[256];

    public static readonly JavaOpCode nop = new((int) JavaCode.nop);
    public static readonly JavaOpCode aconst_null = new((int) JavaCode.aconst_null | (int) JavaStackPush.Object << 24);
    public static readonly JavaOpCode iconst_m1 = new((int) JavaCode.iconst_m1 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_0 = new((int) JavaCode.iconst_0 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_1 = new((int) JavaCode.iconst_1 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_2 = new((int) JavaCode.iconst_2 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_3 = new((int) JavaCode.iconst_3 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_4 = new((int) JavaCode.iconst_4 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode iconst_5 = new((int) JavaCode.iconst_5 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode lconst_0 = new((int) JavaCode.lconst_0 | (int) JavaStackPush.Long << 24);
    public static readonly JavaOpCode lconst_1 = new((int) JavaCode.lconst_1 | (int) JavaStackPush.Long << 24);
    public static readonly JavaOpCode fconst_0 = new((int) JavaCode.fconst_0 | (int) JavaStackPush.Float << 24);
    public static readonly JavaOpCode fconst_1 = new((int) JavaCode.fconst_1 | (int) JavaStackPush.Float << 24);
    public static readonly JavaOpCode fconst_2 = new((int) JavaCode.fconst_2 | (int) JavaStackPush.Float << 24);
    public static readonly JavaOpCode dconst_0 = new((int) JavaCode.dconst_0 | (int) JavaStackPush.Double << 24);
    public static readonly JavaOpCode dconst_1 = new((int) JavaCode.dconst_1 | (int) JavaStackPush.Double << 24);
    public static readonly JavaOpCode bipush = new((int) JavaCode.bipush | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode sipush = new((int) JavaCode.sipush | (int) JavaInstructionSize.Short << 8 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode ldc = new((int) JavaCode.ldc | (int) JavaInstructionSize.Constant4Byte << 8 | (int) JavaStackPush.All4Byte << 24);
    public static readonly JavaOpCode ldc_w = new((int) JavaCode.ldc_w | (int) JavaInstructionSize.Constant4Byte << 8 | (int) JavaStackPush.All4Byte << 24);
    public static readonly JavaOpCode ldc2_w = new((int) JavaCode.ldc2_w | (int) JavaInstructionSize.Constant8Byte << 8 | (int) JavaStackPush.All8Byte << 24);
    public static readonly JavaOpCode iload = new((int) JavaCode.iload | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Int << 24);
    public static readonly JavaOpCode lload = new((int) JavaCode.lload | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Long << 24);
    public static readonly JavaOpCode fload = new((int) JavaCode.fload | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Float << 24);
    public static readonly JavaOpCode dload = new((int) JavaCode.dload | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Double << 24);
    public static readonly JavaOpCode aload = new((int) JavaCode.aload | (int) JavaInstructionSize.Byte << 8 | (int) JavaStackPush.Object << 24);

}