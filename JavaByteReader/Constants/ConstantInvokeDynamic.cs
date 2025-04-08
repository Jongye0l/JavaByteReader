using System;
using System.Collections.Generic;
using System.IO;

namespace JavaByteReader.Constants;

class ConstantInvokeDynamic : Constant {
    public override byte TagCode => 18;
    public ushort bootstrapMethodAttrIndex;
    public ushort nameAndTypeIndex;
    public ConstantNameAndType nameAndType;

    public override void Read(FixedBinaryReader reader) {
        bootstrapMethodAttrIndex = reader.ReadUInt16();
        nameAndTypeIndex = reader.ReadUInt16();
    }

    public override void SetupValue(Constant[] constants) {
        Console.WriteLine("ConstantInvokeDynamic: " + constants[bootstrapMethodAttrIndex]);
        nameAndType = (ConstantNameAndType) constants[nameAndTypeIndex];
    }
}