﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VoipProjectEntities.Domain.Common;


namespace VoipProjectEntities.Domain.Entities
{
    public class MenuAccess: CommonField
    {
        #region MenuAccess - Lucky
        [Key]
        public Guid MenuAccessId { get; set; }
        public bool IsAccess { get; set; }
        public int MenuLink { get; set; }//enum
        public string CustomerId { get; set; }
        #endregion
    }
}
