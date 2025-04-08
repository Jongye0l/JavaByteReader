using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JavaByteReader.Constants;

namespace JavaByteReader;

public class ClassDef : Class {
    public Project Project { get; set; }
    public override string Name { get; set; }
    public ushort MajorVersion { get; set; }
    public ushort MinorVersion { get; set; }
    public ushort AccessFlags { get; set; }
    public ClassRef BaseClass { get; set; }
    public List<ClassRef> Interfaces { get; } = [];
    public List<FieldDef> Fields { get; } = [];
    public List<MethodDef> Methods { get; } = [];
    public List<CustomAttribute> CustomAttributes { get; } = [];

    public string Version => MajorVersion + "." + MinorVersion;

    public static ClassDef Load(string path) {
        using FileStream fs = File.OpenRead(path);
        return Load(fs);
    }

    public static ClassDef Load(byte[] bytes) {
        using MemoryStream stream = new(bytes);
        return Load(stream);
    }

    public static ClassDef Load(Stream stream) => Load(null, stream);

    internal static ClassDef Load(Project project, Stream stream) {
        using FixedBinaryReader reader = new(stream);
        uint magic = reader.ReadUInt32();
        if(magic != 0xCAFEBABE) throw new InvalidDataException("The file is not a valid Java class file.");
        ClassDef classDef = new() {
            MinorVersion = reader.ReadUInt16(),
            MajorVersion = reader.ReadUInt16(),
            Project = project
        };
        Constant[] constants = SetupConstants(reader);
        classDef.AccessFlags = reader.ReadUInt16();
        classDef.Name = ((ConstantClass) constants[reader.ReadUInt16()]).Name;
        project?.Classes.Add(classDef);
        classDef.BaseClass = new ClassRef(project, ((ConstantClass) constants[reader.ReadUInt16()]).Name);
        ushort interfacesCount = reader.ReadUInt16();
        classDef.Interfaces.Capacity = interfacesCount;
        for(int i = 0; i < interfacesCount; i++) classDef.Interfaces.Add(new ClassRef(project, ((ConstantClass) constants[reader.ReadUInt16()]).Name));
        ushort fieldsCount = reader.ReadUInt16();
        classDef.Fields.Capacity = fieldsCount;
        for(int i = 0; i < fieldsCount; i++) {
            FieldDef field = new() {
                AccessFlags = reader.ReadUInt16(),
                Name = ((ConstantUTF8) constants[reader.ReadUInt16()]).data,
                Descriptor = ((ConstantUTF8) constants[reader.ReadUInt16()]).data
            };
            ushort attributesCount = reader.ReadUInt16();
            field.CustomAttributes.Capacity = attributesCount;
            for(int j = 0; j < attributesCount; j++) field.CustomAttributes.Add(new CustomAttribute(reader, constants));
            classDef.Fields.Add(field);
        }
        ushort methodsCount = reader.ReadUInt16();
        classDef.Methods.Capacity = methodsCount;
        for(int i = 0; i < methodsCount; i++) {
            MethodDef method = new() {
                AccessFlags = reader.ReadUInt16(),
                Name = ((ConstantUTF8) constants[reader.ReadUInt16()]).data,
                Descriptor = ((ConstantUTF8) constants[reader.ReadUInt16()]).data
            };
            ushort attributesCount = reader.ReadUInt16();
            method.CustomAttributes.Capacity = attributesCount;
            for(int j = 0; j < attributesCount; j++) method.CustomAttributes.Add(new CustomAttribute(reader, constants));
            classDef.Methods.Add(method);
        }
        ushort cAttributesCount = reader.ReadUInt16();
        classDef.CustomAttributes.Capacity = cAttributesCount;
        for(int i = 0; i < cAttributesCount; i++) classDef.CustomAttributes.Add(new CustomAttribute(reader, constants));
        return classDef;
    }

    private static Constant[] SetupConstants(FixedBinaryReader reader) {
        Constant[] constants = new Constant[reader.ReadUInt16()];
        for(int i = 1; i < constants.Length; i++) {
            byte tag = reader.ReadByte();
            Constant constant = tag switch {
                1 => new ConstantUTF8(),
                3 => new ConstantInteger(),
                4 => new ConstantFloat(),
                5 => new ConstantLong(),
                6 => new ConstantDouble(),
                7 => new ConstantClass(),
                8 => new ConstantString(),
                9 => new ConstantFieldRef(),
                10 => new ConstantMethodRef(),
                11 => new ConstantInterfaceMethodRef(),
                12 => new ConstantNameAndType(),
                15 => new ConstantMethodHandle(),
                16 => new ConstantMethodType(),
                18 => new ConstantInvokeDynamic(),
                _ => throw new InvalidDataException($"Unknown constant tag: {tag}")
            };
            constant.Read(reader);
            foreach(FieldInfo field in constant.GetType().GetFields((BindingFlags) 15420)) {
                object obj = field.GetValue(constant);
                if(obj != null) Console.WriteLine(field.Name + ": " + obj);
            }
            constants[i] = constant;
        }
        foreach(Constant constant in constants) constant?.SetupValue(constants);
        return constants;
    }

    public override ClassDef ToDef() => this;

    public ClassDef() { }

    public ClassDef(Project project) {
        Project = project;
    }
}