using System;
using JavaByteReader.Attribute;
using JavaByteReader.Constants;

namespace JavaByteReader;

public abstract class JavaAttribute {
    public abstract string Name { get; }

    internal static JavaAttribute ReadAttribute(FixedBinaryReader reader, Constant[] constants) {
        ushort nameIndex = reader.ReadUInt16();
        string name = ((ConstantUTF8) constants[nameIndex]).data;
        uint length = reader.ReadUInt32();
        return name switch {
            AttributeConstantValue.AttributeName => new AttributeConstantValue(reader.ReadUInt16()),
            AttributeCode.AttributeName => new AttributeCode(reader, constants),
            AttributeStackMapTable.AttributeName => new AttributeStackMapTable(reader),
            AttributeExceptions.AttributeName => new AttributeExceptions(reader),
            AttributeInnerClasses.AttributeName => new AttributeInnerClasses(reader),
            AttributeEnclosingMethod.AttributeName => new AttributeEnclosingMethod(reader),
            AttributeSynthetic.AttributeName => new AttributeSynthetic(),
            AttributeSignature.AttributeName => new AttributeSignature(reader),
            AttributeSourceFile.AttributeName => new AttributeSourceFile(reader),
            AttributeSourceDebugExtension.AttributeName => new AttributeSourceDebugExtension(reader, length),
            AttributeLineNumberTable.AttributeName => new AttributeLineNumberTable(reader),
            AttributeLocalVariableTable.AttributeName => new AttributeLocalVariableTable(reader),
            AttributeLocalVariableTypeTable.AttributeName => new AttributeLocalVariableTypeTable(reader),
            AttributeDeprecated.AttributeName => new AttributeDeprecated(),
            AttributeRuntimeVisibleAnnotations.AttributeName => new AttributeRuntimeVisibleAnnotations(reader),
            AttributeRuntimeInvisibleAnnotations.AttributeName => new AttributeRuntimeInvisibleAnnotations(reader),
            AttributeRuntimeVisibleParameterAnnotations.AttributeName => new AttributeRuntimeVisibleParameterAnnotations(reader),
            AttributeRuntimeInvisibleParameterAnnotations.AttributeName => new AttributeRuntimeInvisibleParameterAnnotations(reader),
            AttributeAnnotationDefault.AttributeName => new AttributeAnnotationDefault(reader),
            AttributeBootstrapMethods.AttributeName => new AttributeBootstrapMethods(reader),
            _ => throw new NotImplementedException($"Attribute {name} not implemented")
        };
    }

}