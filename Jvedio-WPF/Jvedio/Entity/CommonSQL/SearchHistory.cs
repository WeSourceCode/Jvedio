﻿using Jvedio.Core.Attributes;
using Jvedio.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jvedio.Entity.CommonSQL
{

    [Table(tableName: "common_search_histories")]
    public class SearchHistory
    {

        [TableId(IdType.AUTO)]
        public long ID { get; set; }
        public SearchMode SearchMode { get; set; }
        public SearchField SearchField { get; set; }
        public string SearchValue { get; set; }
        public int CreateYear { get; set; }
        public int CreateMonth { get; set; }
        public int CreateDay { get; set; }
        public string ExtraInfo { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}
