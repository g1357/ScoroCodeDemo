using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    //public static class ScorocodeTypes
    //{
    //    public const string TypeDate = "Date";
    //    public const string TypeBoolean = "Boolean";
    //    public const string TypeString = "String";
    //    public const string TypeFile = "File";
    //    public const string TypeNumber = "Number";
    //    public const string TypePassword = "Password";
    //    public const string TypeArray = "Array";
    //    public const string TypeObject = "Object";
    //    public const string TypeRelation = "Relation";
    //    public const string TypePointer = "Pointer";
    //    public const string TypeWrong = "WrongType";
    //}
    public enum ScorocodeTypes
    {
        TypeDate = 0,       // "Date"
        TypeBoolean = 1,    // "Boolean"
        TypeString = 2,     // "String"
        TypeFile = 3,       // "File"
        TypeNumber = 4,     // "Number" 
        TypePassword = 5,   // "Password"
        TypeArray = 6,      // "Array"
        TypeObject = 7,     // "Object"
        TypeRelation = 8,   // "Relation"
        TypePointer = 9,    // "Pointer"
        TypeWrong = 10      //"WrongType"
    }
    public static class Extensions
    {
        private static Dictionary<int, string> typeNames = new Dictionary<int, string>()
        {
            { 0, "Date" }, { 1, "Boolean" }, { 2, "String" }, { 3, "File" }, { 4, "Number" },
            { 5, "Password" }, { 6, "Array" }, {7, "Object" }, { 8, "Relation" }, { 9, "Pointer" },
            { 10, "WrongType" }
        };

        public static string GetName(this ScorocodeTypes typeCode)
        {
            int index = (int)typeCode;
            return index >= 0 && index <= 10 ? typeNames[index] : typeNames[10];
        }

        public static Dictionary<int, string> Values(this ScorocodeTypes typeCode)
        {
            return typeNames;
        }
    }
}