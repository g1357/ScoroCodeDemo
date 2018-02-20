using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Query
    {
        //package ru.profit_group.scorocode_sdk.scorocode_objects;
        //import android.support.annotation.NonNull;
        //import com.google.gson.Gson;
        //import com.google.gson.internal.LinkedHashTreeMap;
        //import com.google.gson.internal.LinkedTreeMap;
        //import java.util.ArrayList;
        //import java.util.HashMap;
        //import java.util.List;
        //import java.util.Map;
        //import retrofit2.Callback;
        private string collectionName;
        private int limit;
        private int skip;
        private Sort sort;
        private List<String> fieldIds;
        private QueryInfo queryInfo;

        public Query(String collectionName)
        {
            this.collectionName = collectionName;
            this.sort = new Sort();
            this.queryInfo = new QueryInfo();
        }

        //public void findDocuments(CallbackFindDocument callback)
        //{
        //    ScorocodeSdk.findDocument(collectionName, this, sort, fieldIds, limit, skip, callback);
        //}

        //public void countDocuments(CallbackCountDocument callback)
        //{
        //    ScorocodeSdk.getDocumentsCount(collectionName, this, callback);
        //}

        //public void updateDocument(Update update, CallbackUpdateDocument callback)
        //{
        //    UpdateInfo doc = update.getUpdateInfo();
        //    ScorocodeSdk.updateDocument(collectionName, this, doc, limit, callback);
        //}

        //public void removeDocument(CallbackRemoveDocument callback)
        //{
        //    ScorocodeSdk.removeDocument(collectionName, this, limit, callback);
        //}

        public void setLimit(int limit)
        {
            this.limit = limit;
        }

        public void setSkip(int skip)
        {
            this.skip = skip;
        }

        public void setPage(int page)
        {
            if (page > 0)
            {
                skip = (page - 1) * limit;
            }
        }

        public Query equalTo(string field, object value)
        {
            addQueryRule(field, "$eq", value);
            return this;
        }

        public Query notEqualTo(string field, object value)
        {
            addQueryRule(field, "$ne", value);
            return this;
        }

        public Query containedIn(String field, List<Object> values)
        {
            addQueryRule(field, "$in", values);
            return this;
        }

        public Query containsAll(String field, List<Object> values)
        {
            addQueryRule(field, "$all", values);
            return this;
        }

        public Query notContainedIn(String field, List<Object> values)
        {
            addQueryRule(field, "$nin", values);
            return this;
        }

        public Query greaterThan(String field, Object value)
        {
            addQueryRule(field, "$gt", value);
            return this;
        }

        public Query greaterThenOrEqualTo(String field, Object value)
        {
            addQueryRule(field, "$gte", value);
            return this;
        }

        public Query lessThan(String field, Object value)
        {
            addQueryRule(field, "$lt", value);
            return this;
        }

        public Query lessThanOrEqualTo(String field, Object value)
        {
            addQueryRule(field, "$lte", value);
            return this;
        }

        public Query exists(String field)
        {
            addQueryRule(field, "$exists", true);
            return this;
        }

        public Query doesNotExist(String field)
        {
            addQueryRule(field, "$exists", false);
            return this;
        }

        public Query contains(String field, String regEx, RegexOptions options)
        {
            Dictionary<string, object> operationMap = new Dictionary<string, object>();
            operationMap.Add("$regex", regEx);
            operationMap.Add("$options", options.getRegexOptions());
            queryInfo.Add(field, operationMap);
            return this;
        }

        public Query startsWith(string field, string str, RegexOptions options)
        {
            Dictionary<string, object> operationMap = new Dictionary<string, object>();
            operationMap.Add("$regex", "^" + str);
            if (options != null)
            {
                operationMap.Add("$options", options.getRegexOptions());
            }
            queryInfo.Add(field, operationMap);
            return this;
        }

        public Query startsWith(string field, string str)
        {
            return startsWith(field, str, null);
        }

        public Query endsWith(string field, string str, RegexOptions options)
        {
            Dictionary<String, Object> operationMap = new Dictionary<string, object>();
            operationMap.Add("$regex", str + "$");
            if (options != null)
            {
                operationMap.Add("$options", options.getRegexOptions());
            }
            queryInfo.Add(field, operationMap);
            return this;
        }

        public Query endsWith(string field, string str)
        {
            return endsWith(field, str, null);
        }

        public Query and(string field, Query query)
        {
            try
            {
                List<Dictionary<string, Dictionary<string, object>>> list = new List<Dictionary<string, Dictionary<string, object>>>();
                Dictionary<string, object> queryParam1 = (Dictionary<string, Object>)query.getQueryInfo().GetValueOrDefault(field);
                Dictionary<string, object> queryParam2 = (Dictionary<string, Object>)queryInfo.GetValueOrDefault(field);
                Dictionary<string, Dictionary<string, object>> parameter1 = new Dictionary<string, Dictionary<string, object>>();
                parameter1.Add(field, queryParam1);
                Dictionary<string, Dictionary<String, Object>> parameter2 = new Dictionary<string, Dictionary<string, object>>();
                parameter2.Add(field, queryParam2);
                list.Add(parameter1);
                list.Add(parameter2);
                queryInfo.Remove(field);
                queryInfo.Add("$and", list);
            }
            catch (Exception ex)
            {
                //e.printStackTrace();
                throw ex;
            }
            return this;
        }

        public Query or(string field, Query query)
        {
            try
            {
                List<Dictionary<String, Dictionary<String, Object>>> list = new List<Dictionary<string, Dictionary<string, object>>>();
                Dictionary<string, object> queryParam1 = (Dictionary<string, object>)query.getQueryInfo().GetValueOrDefault(field);
                Dictionary<string, object> queryParam2 = (Dictionary<string, object>)queryInfo.GetValueOrDefault(field);
                Dictionary<string, Dictionary<string, object>> parameter1 = new Dictionary<string, Dictionary<string, object>>();
                parameter1.Add(field, queryParam1);
                Dictionary<string, Dictionary<string, object>> parameter2 = new Dictionary<string, Dictionary<string, object>>();
                parameter2.Add(field, queryParam2);
                list.Add(parameter1);
                list.Add(parameter2);
                queryInfo.Remove(field);
                queryInfo.Add("$or", list);
            }
            catch (Exception ex)
            {
                //e.printStackTrace();
                throw ex;
            }
            return this;
        }

        private static Dictionary<string, object> getRecord(object value, string oper)
        {
            Dictionary<String, Object> record = new Dictionary<string, object>();
            record.Add(oper, value);
            return record;
        }

        public void raw(string json)
        {
            //    Gson gson = new Gson();
            //    QueryInfo query = gson.fromJson(json, QueryInfo.class);
            //reset();
            //queryInfo.putAll(query);
        }

        private void addQueryRule(String field, String operation, Object value)
        {
            Dictionary<string, object> element = (Dictionary<String, Object>)queryInfo.GetValueOrDefault(field);
            if (queryInfo.ContainsKey(field))
            {
                element.Add(operation, value);
            }
            else
            {
                queryInfo.Add(field, getRecord(value, operation));
            }
        }

        public QueryInfo getQueryInfo()
        {
            return queryInfo;
        }

        public void reset()
        {
            queryInfo.Clear();
            sort = null;
            fieldIds = null;
        }

        public void ascending(String field)
        {
            sort.Add(field, 1);
        }

        public void descending(String field)
        {
            sort.Add(field, -1);
        }

        public void setFieldsForSearch(List<string> fields)
        {
            fieldIds = fields;
        }

        public String getCollectionName()
        {
            return collectionName;
        }
    }
}