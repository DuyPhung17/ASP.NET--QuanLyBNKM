﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TEST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class BACSI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BACSI()
        {
            this.CT_HSBA = new HashSet<CT_HSBA>();
        }
        [DisplayName ("Mã Bác Sĩ")]
        public int MABS { get; set; }
        [DisplayName("Tên Bác Sĩ")]
        public string TENBS { get; set; }
        [DisplayName("Ngày Sinh")]
        public System.DateTime NGAYSINHBS { get; set; }
        [DisplayName("SĐT")]
        public string SDTBS { get; set; }
        [DisplayName("Địa Chỉ")]
        public string DIACHIBS { get; set; }
        [DisplayName("Chuyên Môn")]
        public string CHUYENMON { get; set; }
        [DisplayName("Trình Độ")]
        public string TRINHDO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HSBA> CT_HSBA { get; set; }
    }
}
