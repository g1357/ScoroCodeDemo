using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSON
{
    public class Bson
    {
        // BSON.java

        /**
         *      Copyright (C) 2008 10gen Inc.
         *
         *   Licensed under the Apache License, Version 2.0 (the "License");
         *   you may not use this file except in compliance with the License.
         *   You may obtain a copy of the License at
         *
         *      http://www.apache.org/licenses/LICENSE-2.0
         *
         *   Unless required by applicable law or agreed to in writing, software
         *   distributed under the License is distributed on an "AS IS" BASIS,
         *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
         *   See the License for the specific language governing permissions and
         *   limitations under the License.
         */

        //package org.bson;

        //import java.nio.charset.Charset;
        //import java.util.HashMap;
        //import java.util.List;
        //import java.util.Map;
        //import java.util.concurrent.CopyOnWriteArrayList;
        //import java.util.logging.Logger;
        //import java.util.regex.Pattern;

        //import org.bson.util.ClassMap;

        //static Logger LOGGER = Logger.getLogger("org.bson.BSON");

        // ---- basics ----

        public static readonly byte EOO = 0;
        public static readonly byte NUMBER = 1;
        public static readonly byte STRING = 2;
        public static readonly byte OBJECT = 3;
        public static readonly byte ARRAY = 4;
        public static readonly byte BINARY = 5;
        public static readonly byte UNDEFINED = 6;
        public static readonly byte OID = 7;
        public static readonly byte BOOLEAN = 8;
        public static readonly byte DATE = 9;
        public static readonly byte NULL = 10;
        public static readonly byte REGEX = 11;
        public static readonly byte REF = 12;
        public static readonly byte CODE = 13;
        public static readonly byte SYMBOL = 14;
        public static readonly byte CODE_W_SCOPE = 15;
        public static readonly byte NUMBER_INT = 16;
        public static readonly byte TIMESTAMP = 17;
        public static readonly byte NUMBER_LONG = 18;

        public static readonly byte MINKEY = -1;
        public static readonly byte MAXKEY = 127;

        // --- binary types
        /*
           these are binary types
           so the format would look like
           <BINARY><name><BINARY_TYPE><...>
         */

        public static readonly byte B_GENERAL = 0;
        public static readonly byte B_FUNC = 1;
        public static readonly byte B_BINARY = 2;
        public static readonly byte B_UUID = 3;

        // ---- regular expression handling ----

        /** Converts a string of regular expression flags from the database in Java regular
         * expression flags.
         * @param flags flags from database
         * @return the Java flags
         */
        public static int regexFlags(string flags)
        {
            int fint = 0;
            if (flags == null || flags.Length == 0)
                return fint;

            flags = flags.ToLower();

            for (int i = 0; i < flags.Length; i++)
            {
                RegexFlagS flag = RegexFlag.getByCharacter(flags.ElementAt(i));
                if (flag != null)
                {
                    fint |= flag.javaFlag;
                    if (flag.unsupported != null)
                        _warnUnsupportedRegex(flag.unsupported);
                }
                else
                {
                    throw new ArgumentException("unrecognized flag ["
                            + flags.ElementAt(i) + "] " + (int)flags.ElementAt(i));
                }
            }
            return fint;
        }

        public static int regexFlag(char c)
        {
            RegexFlag flag = RegexFlag.getByCharacter(c);
            if (flag == null)
                throw new IllegalArgumentException("unrecognized flag [" + c
                        + "]");

            if (flag.unsupported != null)
            {
                _warnUnsupportedRegex(flag.unsupported);
                return 0;
            }

            return flag.javaFlag;
        }

        /** Converts Java regular expression flags into a string of flags for the database
         * @param flags Java flags
         * @return the flags for the database
         */
        public static String regexFlags(int flags)
        {
            StringBuilder buf = new StringBuilder();

            for (RegexFlag flag : RegexFlag.values())
            {
                if ((flags & flag.javaFlag) > 0)
                {
                    buf.Append(flag.flagChar);
                    flags -= flag.javaFlag;
                }
            }

            if (flags > 0)
                throw new ArgumentException(
                        "some flags could not be recognized.");

            return buf.ToString();
        }

        private enum Pattern : int
        {
            CANON_EQ = 128,
            CASE_INSENSITIVE = 2,
            COMMENTS = 4,
            DOTALL = 32,
            LITERAL = 16,
            MULTILINE = 8,
            UNICODE_CASE = 64,
            UNICODE_CHARACTER_CLASS = 256,
            UNIX_LINES = 1
        }

        private struct RegexFlagS
        {
            public readonly int javaFlag;
            public readonly char flagChar;
            public readonly string unsupported;

            public RegexFlagS(int f, char ch, String u)
            {
                javaFlag = f;
                flagChar = ch;
                unsupported = u;
            }
            public RegexFlagS(Pattern f, char ch, String u)
            {
                javaFlag = (int)f;
                flagChar = ch;
                unsupported = u;
            }
        }
        //private static enum RegexFlag
        private class RegexFlag
        {
            static RegexFlagS CANON_EQ = new RegexFlagS(Pattern.CANON_EQ, 'c', "Pattern.CANON_EQ");
            static RegexFlagS UNIX_LINES = new RegexFlagS(Pattern.UNIX_LINES, 'd', "Pattern.UNIX_LINES");
            static RegexFlagS GLOBAL = new RegexFlagS(GLOBAL_FLAG, 'g', null);
            static RegexFlagS CASE_INSENSITIVE = new RegexFlagS(Pattern.CASE_INSENSITIVE, 'i', null);
            static RegexFlagS MULTILINE = new RegexFlagS(Pattern.MULTILINE, 'm', null);
            static RegexFlagS DOTALL = new RegexFlagS(Pattern.DOTALL, 's', "Pattern.DOTALL");
            static RegexFlagS LITERAL = new RegexFlagS(Pattern.LITERAL, 't', "Pattern.LITERAL");
            static RegexFlagS UNICODE_CASE = new RegexFlagS(Pattern.UNICODE_CASE, 'u', "Pattern.UNICODE_CASE");
            static RegexFlagS COMMENTS = new RegexFlagS(Pattern.COMMENTS, 'x', null);

            private static Dictionary<char, RegexFlagS> byCharacter = new Dictionary<char, RegexFlagS>()
            {
                { 'c', new RegexFlagS(Pattern.CANON_EQ, 'c', "Pattern.CANON_EQ") },
                { 'd', new RegexFlagS(Pattern.UNIX_LINES, 'd', "Pattern.UNIX_LINES") },
                { 'g', new RegexFlagS(GLOBAL_FLAG, 'g', null) },
                { 'i', new RegexFlagS(Pattern.CASE_INSENSITIVE, 'i', null) },
                { 'm', new RegexFlagS(Pattern.MULTILINE, 'm', null) },
                { 's', new RegexFlagS(Pattern.DOTALL, 's', "Pattern.DOTALL") },
                { 't', new RegexFlagS(Pattern.LITERAL, 't', "Pattern.LITERAL") },
                { 'u', new RegexFlagS(Pattern.UNICODE_CASE, 'u', "Pattern.UNICODE_CASE") },
                { 'x', new RegexFlagS(Pattern.COMMENTS, 'x', null) }
            };

            public static RegexFlagS getByCharacter(char ch)
            {
                return byCharacter.GetValueOrDefault(ch);
            }

            public readonly int javaFlag;
            public readonly char flagChar;
            public readonly string unsupported;

            RegexFlag(int f, char ch, String u)
            {
                javaFlag = f;
                flagChar = ch;
                unsupported = u;
            }

            private static void _warnUnsupportedRegex(String flag)
            {
                //LOGGER.info("flag " + flag + " not supported by db.");
            }

            private static readonly int GLOBAL_FLAG = 256;

            // --- (en|de)coding hooks -----

            public static bool hasDecodeHooks()
            {
                return _decodeHooks;
            }

            public static void addEncodingHook(Class c, Transformer t)
            {
                _encodeHooks = true;
                List<Transformer> l = _encodingHooks.get(c);
                if (l == null)
                {
                    l = new CopyOnWriteArrayList<Transformer>();
                    _encodingHooks.put(c, l);
                }
                l.add(t);
            }

            public static void addDecodingHook(Class c, Transformer t)
            {
                _decodeHooks = true;
                List<Transformer> l = _decodingHooks.get(c);
                if (l == null)
                {
                    l = new CopyOnWriteArrayList<Transformer>();
                    _decodingHooks.put(c, l);
                }
                l.add(t);
            }

            public static object applyEncodingHooks(object o)
            {
                if (!_anyHooks())
                    return o;

                if (_encodingHooks.size() == 0 || o == null)
                    return o;
                List<Transformer> l = _encodingHooks.get(o.getClass());
                if (l != null)
                    for (Transformer t : l)
                        o = t.transform(o);
                return o;
            }

            public static Object applyDecodingHooks(Object o)
            {
                if (!_anyHooks() || o == null)
                    return o;

                List<Transformer> l = _decodingHooks.get(o.getClass());
                if (l != null)
                    for (Transformer t : l)
                        o = t.transform(o);
                return o;
            }

            /**
             * Returns the encoding hook(s) associated with the specified class
             *
             */
            public static List<Transformer> getEncodingHooks(Class c)
            {
                return _encodingHooks.get(c);
            }

            /**
             * Clears *all* encoding hooks.
             */
            public static void clearEncodingHooks()
            {
                _encodeHooks = false;
                _encodingHooks.clear();
            }

            /**
             * Remove all encoding hooks for a specific class.
             */
            public static void removeEncodingHooks(Class c)
            {
                _encodingHooks.remove(c);
            }

            /**
             * Remove a specific encoding hook for a specific class.
             */
            public static void removeEncodingHook(Class c, Transformer t)
            {
                getEncodingHooks(c).remove(t);
            }

            /**
             * Returns the decoding hook(s) associated with the specific class
             */
            public static List<Transformer> getDecodingHooks(Class c)
            {
                return _decodingHooks.get(c);
            }

            /**
             * Clears *all* decoding hooks.
             */
            public static void clearDecodingHooks()
            {
                _decodeHooks = false;
                _decodingHooks.clear();
            }

            /**
             * Remove all decoding hooks for a specific class.
             */
            public static void removeDecodingHooks(Class c)
            {
                _decodingHooks.remove(c);
            }

            /**
             * Remove a specific encoding hook for a specific class.
             */
            public static void removeDecodingHook(Class c, Transformer t)
            {
                getDecodingHooks(c).remove(t);
            }

            public static void clearAllHooks()
            {
                clearEncodingHooks();
                clearDecodingHooks();
            }

            /**
             * Returns true if any encoding or decoding hooks are loaded.
             */
            private static bool _anyHooks()
            {
                return _encodeHooks || _decodeHooks;
            }

            private static bool _encodeHooks = false;
            private static bool _decodeHooks = false;
            static ClassMap<List<Transformer>> _encodingHooks = new ClassMap<List<Transformer>>();

            static ClassMap<List<Transformer>> _decodingHooks = new ClassMap<List<Transformer>>();

            static protected Charset _utf8 = Charset.forName("UTF-8");

            // ----- static encode/decode -----

            public static byte[] encode(BSONObject o)
            {
                BSONEncoder e = _staticEncoder.get();
                try
                {
                    return e.encode(o);
                }
                finally
                {
                    e.done();
                }
            }

            public static BSONObject decode(byte[] b)
            {
                BSONDecoder d = _staticDecoder.get();
                return d.readObject(b);
            }

            static ThreadLocal<BSONEncoder> _staticEncoder = new ThreadLocal<BSONEncoder>()
            {
        protected BSONEncoder initialValue()
            {
                return new BasicBSONEncoder();
            }
        };

        static ThreadLocal<BSONDecoder> _staticDecoder = new ThreadLocal<BSONDecoder>()
        {
        protected BSONDecoder initialValue()
        {
            return new BasicBSONDecoder();
        }
    };

    // --- coercing ---

    public static int toInt(object o)
    {
        if (o == null)
            throw new ArgumentNullException("can't be null");

        if (o instanceof Number)
            return ((Number)o).intValue();

        if (o instanceof Boolean)
            return ((Boolean)o) ? 1 : 0;

        throw new IllegalArgumentException("can't convert: "
                + o.getClass().getName() + " to int");
    }
}
    }