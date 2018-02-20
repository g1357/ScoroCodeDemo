using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class Document
    {
        /// <summary>
        /// Инициализация экреспляра класса Document
        /// </summary>
        /// <param name="collectionName">
        /// Имя коллекции в которой будеи идти работа с докусентом
        /// </param>
        public Document(string collectionName)
        {

        }

        /// <summary>
        /// Установка значения поля документа
        /// </summary>
        /// <param name="field">Название поля</param>
        /// <param name="value">Новое значение поля</param>
        public void SetField(string field, object value)
        {

        }
        public void SaveDocument(CallbackDocumentSaved callBack)
        {

        }
        public void SaveDocument(Delegate success, Delegate fail = null)
        {

        }

        public void GetDocumentById(string documentId, Delegate callBack)
        {

        }

        public object GetField(string fieldName)
        {
            return null;
        }

        public void UpdateDocument()
        {

        }

        public void UploadFile(string fieldName, string fileName, string contentToUploadInBase64, Delegate callbackUpdateFile)
        {

        }

        public string GetFileLink(string fieldName, string fileName)
        {
            return string.Empty;
        }

        public void RemoveFile(string fieldName, string fileName, Delegate calbackDeletefile)
        {

        }

        public void RemoveDocument(CallbackRemoveDocument callback)
        {

        }
    }
}

