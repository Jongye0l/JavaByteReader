using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JavaByteReader;

public class Project {
    public UTF8String Name { get; set; }
    public List<ClassDef> Classes => classes;

    private readonly List<ClassDef> classes = [];

    public static Project Load(string path) {
        using FileStream stream = File.OpenRead(path);
        return Load(stream);
    }

    public static Project Load(byte[] bytes) {
        using MemoryStream stream = new MemoryStream(bytes);
        return Load(stream);
    }

    public static Project Load(Stream stream) {
        throw new NotImplementedException();
    }

    public ClassDef FindClass(UTF8String name) {
        return classes.FirstOrDefault(classDef => classDef.Name.Equals(name));
    }
}