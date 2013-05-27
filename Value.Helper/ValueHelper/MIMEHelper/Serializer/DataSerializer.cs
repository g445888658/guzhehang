/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 11.6.2012                |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.Net.Mime;
using System.Text.RegularExpressions;
using ValueHelper.MIMEHelper.Infrastructure;

namespace ValueHelper.MIMEHelper.Serializer
{
    public partial class DataSerializer
    {
        public DataSerializer(String mime)
        {
            MIME = String.Concat("\r\n", mime);
        }

        public String SerializeFrom()
        {
            return SerializeFrom(null);
        }

        public String SerializeDate()
        {
            return SerializeDate(null);
        }

        public String SerializeSubject()
        {
            return SerializeSubject(null);
        }

        public String SerializeContentEncoding()
        {
            return SerializeContentEncoding(null);
        }

        public ContentType SerializeContentType()
        {
            return SerializeContentType(null);
        }
    }

    public partial class DataSerializer
    {
        private static String MIME;

        private static String MIMEDecode(String value)
        {
            var result = String.Empty;
            result = Regex.Replace(value, MIMETemplate.EncodeTemplate, new MatchEvaluator(delegate(Match match)
            {
                var charset = match.Groups["charset"].Value;
                var entype = match.Groups["entype"].Value;
                var data = match.Groups["data"].Value;

                return MIMEncrypt.ConvertEncoding(charset, entype, data);
            }));

            return result;
        }

        public static String SerializeFrom(String data)
        {
            var value = data ?? MIME;

            var from = Regex.Match(value, MIMETemplate.From).Groups["from"].Value;
            return MIMEDecode(from);
        }

        public static String SerializeDate(String data)
        {
            var value = data ?? MIME;

            var date = Regex.Match(value, MIMETemplate.Date).Groups["date"].Value;
            return date;
        }

        public static String SerializeSubject(String data)
        {
            var value = data ?? MIME;
            var subject = String.Empty;
            var matchs = Regex.Matches(value, MIMETemplate.Subject);
            foreach (var item in matchs)
            {

            }

            var groups = Regex.Match(value, MIMETemplate.Subject).Groups;
            for (int i = 1; i <= 5; i++)
            {
                if (groups["g" + i].Value != String.Empty)
                    subject = String.Concat(subject, groups["g" + i].Value);
            }

            return MIMEDecode(subject);
        }

        public static String SerializeContext(String data)
        {
            var context = Regex.Match(data, MIMETemplate.Context).Groups["context"].Value;
            return context;
        }

        public static String SerializeContentEncoding(String data)
        {
            var value = data ?? MIME;

            var groups = Regex.Match(value, MIMETemplate.ContentEncoding).Groups;
            var contentEncoding = groups["encoding"].Value;
            return contentEncoding;
        }

        public static ContentType SerializeContentType(String data)
        {
            var value = data ?? MIME;

            var contentType = new ContentType();
            var groups = Regex.Match(value, MIMETemplate.ContentType).Groups;
            contentType.MediaType = groups["type"].Value;
            contentType.Boundary = groups["boundary"].Value;
            contentType.CharSet = groups["charset"].Value;
            contentType.Name = groups["name"].Value;
            return contentType;
        }
    }
}
