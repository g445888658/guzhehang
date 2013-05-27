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
using ValueHelper.MIMEHelper.Serializer;
using ValueHelper.MIMEHelper.Infrastructure;

namespace ValueHelper.MIMEHelper
{
    public class ValueMIME
    {
        public static MIMEHead SerializeMIMEHead(String mime)
        {
            DataSerializer serializer = getSerializer(mime);

            MIMEHead mimeHead = new MIMEHead();
            var from = serializer.SerializeFrom();
            if (from != String.Empty)
                mimeHead.Add(MIMEPrefix.From, from);

            var date = serializer.SerializeDate();
            if (date != String.Empty)
                mimeHead.Add(MIMEPrefix.Date, date);

            var subject = serializer.SerializeSubject();
            if (subject != String.Empty)
                mimeHead.Add(MIMEPrefix.Subject, subject);

            var contentEncoding = serializer.SerializeContentEncoding();
            if (contentEncoding != String.Empty)
                mimeHead.Add(MIMEPrefix.ContentEncoding, contentEncoding);

            var contentType = serializer.SerializeContentType();
            mimeHead.Add(MIMEPrefix.MediaType, contentType.MediaType);
            if (!String.IsNullOrEmpty(contentType.Boundary))
                mimeHead.Add(MIMEPrefix.Boundary, contentType.Boundary);
            if (!String.IsNullOrEmpty(contentType.CharSet))
                mimeHead.Add(MIMEPrefix.Charset, contentType.CharSet);

            return mimeHead;
        }

        public static MIMEModel SerializeMIME(String mime)
        {
            DataSerializer serializer = getSerializer(mime);
            var head = SerializeMIMEHead(mime);
            var model = new MIMEModel();
            model.AddHead(head);
            var boundary = String.Concat("--", head[MIMEPrefix.Boundary]);
            serializeMIME(ref model, boundary, mime);
            return model;
        }

        private static DataSerializer getSerializer(String mime)
        {
            return new DataSerializer(mime);
        }

        private static String[] pickupPartial(String boundary, String mime)
        {
            var boundaryPattern = MIMETemplate.PartialBody(boundary);
            var data = Regex.Match(mime, boundaryPattern).Groups["data"].Value;

            var partials = data.Split(new String[] { boundary }, StringSplitOptions.RemoveEmptyEntries);
            return partials;
        }

        /// <summary>
        ///  最终封装model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mime"></param>
        private static void serializeMIME(ref MIMEModel model, String mime)
        {
            var contentType = DataSerializer.SerializeContentType(mime);
            if (String.IsNullOrEmpty(contentType.Boundary))
            {
                var contentEncoding = DataSerializer.SerializeContentEncoding(mime);
                var data = DataSerializer.SerializeContext(mime);

                switch (contentType.MediaType)
                {
                    case MediaTypeNames.Text.Plain:
                        model.Add(MIMEPrefix.BodyText, MIMEncrypt.ConvertEncoding(contentType.CharSet, contentEncoding, data));
                        break;
                    case MediaTypeNames.Text.Html:
                        model.Add(MIMEPrefix.BodyHtml, MIMEncrypt.ConvertEncoding(contentType.CharSet, contentEncoding, data));
                        break;
                    case MediaTypeNames.Application.Octet:
                    case MediaTypeNames.Image.Gif:
                    case MediaTypeNames.Image.Jpeg:
                        model.AddAttachment(new Attachment
                        {
                            Name = contentType.Name,
                            Data = MIMEncrypt.GetBytesByPattern(contentEncoding, data)
                        });
                        break;
                    default:
                        break;
                }
            }
            else
            {
                var boundary = String.Concat("--", contentType.Boundary);
                serializeMIME(ref model, boundary, mime);
            }
        }

        private static void serializeMIME(ref MIMEModel model, String boundary, String mime)
        {
            var partials = pickupPartial(boundary, mime);
            if (partials.Length == 0 && !String.IsNullOrEmpty(mime))
                model.Add(MIMEPrefix.BodyHtml, mime.Split(new String[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1]);

            for (int i = 0; i < partials.Length; i++)
            {
                serializeMIME(ref model, partials[i]);
            }
        }

    }
}
