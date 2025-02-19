﻿using Jvedio.Entity;
using Jvedio.Logs;
using Jvedio.Utils.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jvedio.Utils.IO
{
    public static class NFOHelper
    {
        /// <summary>
        /// 保存信息到 NFO 文件
        /// </summary>
        /// <param name="video"></param>
        /// <param name="NfoPath"></param>
        public static void SaveToNFO(Video video, string NfoPath)
        {
            var nfo = new NFO(NfoPath, "movie");
            nfo.SetNodeText("source", video.WebUrl);
            nfo.SetNodeText("title", video.Title);
            nfo.SetNodeText("director", video.Director);
            nfo.SetNodeText("rating", video.Rating.ToString());
            nfo.SetNodeText("year", video.ReleaseYear.ToString());
            //nfo.SetNodeText("countrycode", video.Country.ToString());
            nfo.SetNodeText("release", video.ReleaseDate);
            nfo.SetNodeText("premiered", video.ReleaseDate);
            nfo.SetNodeText("runtime", video.Duration.ToString());
            nfo.SetNodeText("country", video.Country);
            nfo.SetNodeText("studio", video.Studio);
            nfo.SetNodeText("id", video.VID);
            nfo.SetNodeText("num", video.VID);

            // 类别
            foreach (var item in video.Genre?.Split(GlobalVariable.Separator))
            {
                if (!string.IsNullOrEmpty(item)) nfo.AppendNewNode("genre", item);
            }
            // 系列
            foreach (var item in video.Series?.Split(GlobalVariable.Separator))
            {
                if (!string.IsNullOrEmpty(item)) nfo.AppendNewNode("tag", item);
            }


            try
            {
                Dictionary<string, object> dict = JsonUtils.TryDeserializeObject<Dictionary<string, object>>(video.ImageUrls);
                if (dict != null && dict.ContainsKey("ExtraImageUrl"))
                {
                    List<string> imageUrls = JsonUtils.TryDeserializeObject<List<string>>(dict["ExtraImageUrl"].ToString());
                    if (imageUrls != null && imageUrls.Count > 0)
                    {
                        nfo.AppendNewNode("fanart");
                        foreach (var item in imageUrls)
                        {
                            if (!string.IsNullOrEmpty(item))
                                nfo.AppendNodeToNode("fanart", "thumb", item, "preview", item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }




            if (video.ActorInfos != null && video.ActorInfos.Count > 0)
            {
                foreach (ActorInfo info in video.ActorInfos)
                {
                    if (!string.IsNullOrEmpty(info.ActorName))
                    {
                        nfo.AppendNewNode("actor");
                        nfo.AppendNodeToNode("actor", "name", info.ActorName);
                        nfo.AppendNodeToNode("actor", "type", "Actor");
                    }
                }
            }
        }
    }
}
