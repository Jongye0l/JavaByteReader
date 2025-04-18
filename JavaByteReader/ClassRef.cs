﻿using System;

namespace JavaByteReader;

public class ClassRef : Class {
    private Project project;
    public override string Name { get; set; }
    public override ClassDef ToDef() {
        if(project != null) foreach(ClassDef classDef in project.Classes) {
            ClassDef findClass = project.FindClass(Name);
            if(findClass != null) return findClass;
        }
        throw new MissingMethodException("Class not found in project");
    }

    internal ClassRef(Project project, string name) {
        this.project = project;
        Name = name;
    }
}