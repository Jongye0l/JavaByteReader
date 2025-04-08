using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantInterfaceMethodRef : Constant {

    public override byte TagCode => 11;
    public ushort ClassIndex;
    public ushort NameAndTypeIndex;
    public ConstantClass Class;
    public ConstantNameAndType NameAndType;

    public override void Read(FixedBinaryReader reader) {
        ClassIndex = reader.ReadUInt16();
        NameAndTypeIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        Class = (ConstantClass) constants[ClassIndex];
        NameAndType = (ConstantNameAndType) constants[NameAndTypeIndex];
    }
}