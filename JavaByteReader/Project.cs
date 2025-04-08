using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JavaByteReader;

public class Project {
    public string Name { get; set; }
    public List<ClassDef> Classes { get; } = [];

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

    public ClassDef FindClass(string name) {
        return Classes.FirstOrDefault(classDef => classDef.Name.Equals(name));
    }
}