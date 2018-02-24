using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epesu.bson
{
    public static class Bson
    {
        public static string ConvertToJson(string bsonString)
        {
            StringBuilder jsonString = new StringBuilder();
            string nameStr;
            string valueStr;
            Stack<string> stack = new Stack<string>();
            string stackTop;
            Stack<bool> stackFirst = new Stack<bool>();

            byte[] buffer = Convert.FromBase64String(bsonString);
            string text = Encoding.UTF8.GetString(buffer);
            using (var stream = new MemoryStream(buffer))
            using (var reader = new BsonBinaryReader(stream))
            {
                bool exit = false;
                bool firstElem = true;
                reader.ReadStartDocument();
                jsonString.Append("{ ");
                while (!reader.IsAtEndOfFile() && !exit)
                {
                    var bsonType = reader.ReadBsonType(); //.CurrentBsonType;
                    switch (bsonType)
                    {
                        case MongoDB.Bson.BsonType.Array:
                            nameStr = reader.ReadName();
                            reader.ReadStartArray();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : [ ");
                            stack.Push("Array");
                            stackFirst.Push(firstElem);
                            firstElem = true;
                            break;
                        case MongoDB.Bson.BsonType.Binary:
                            break;
                        case MongoDB.Bson.BsonType.Boolean:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadBoolean().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.DateTime:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Decimal128:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadDecimal128().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Document:
                            nameStr = reader.ReadName();
                            reader.ReadStartDocument();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : {{ ");
                            stack.Push("Document");
                            stackFirst.Push(firstElem);
                            firstElem = true;
                            break;
                        case MongoDB.Bson.BsonType.Double:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadDouble().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.EndOfDocument:
                            if (stack.Count == 0)
                            {
                                jsonString.Append("} ");
                                exit = true;
                            }
                            else
                            {
                                stackTop = stack.Pop();
                                firstElem = stackFirst.Pop();
                                switch (stackTop)
                                {
                                    case "Array":
                                        jsonString.Append("]");
                                        reader.ReadEndArray();
                                        break;
                                    case "Document":
                                        jsonString.Append("}");
                                        reader.ReadEndDocument();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case MongoDB.Bson.BsonType.Int32:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadInt32().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Int64:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadInt64().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.JavaScript:
                            break;
                        case MongoDB.Bson.BsonType.JavaScriptWithScope:
                            break;
                        case MongoDB.Bson.BsonType.MaxKey:
                            nameStr = reader.ReadName();
                            reader.ReadMaxKey();
                            valueStr = "";
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.MinKey:
                            nameStr = reader.ReadName();
                            reader.ReadMinKey();
                            valueStr = "";
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Null:
                            nameStr = reader.ReadName();
                            reader.ReadNull();
                            valueStr = "null";
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.ObjectId:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadObjectId().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.RegularExpression:
                            break;
                        case MongoDB.Bson.BsonType.String:
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            if (reader.State == BsonReaderState.Name)
                            {
                                nameStr = reader.ReadName();
                                jsonString.Append($"\"{nameStr}\" : ");
                            }
                            valueStr = reader.ReadString();
                            jsonString.Append($"\"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Symbol:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadSymbol();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Timestamp:
                            nameStr = reader.ReadName();
                            valueStr = reader.ReadTimestamp().ToString();
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        case MongoDB.Bson.BsonType.Undefined:
                            nameStr = reader.ReadName();
                            reader.ReadUndefined();
                            valueStr = "undefined";
                            if (firstElem) { firstElem = false; }
                            else { jsonString.Append(", "); }
                            jsonString.Append($"\"{nameStr}\" : \"{valueStr}\"");
                            break;
                        default:
                            break;
                    }
                }
                reader.ReadEndDocument();
            }


            return jsonString.ToString(); ;
        }

    }
}
