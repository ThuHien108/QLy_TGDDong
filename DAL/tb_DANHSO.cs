//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_DANHSO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_DANHSO()
        {
            this.tb_DANHSOCHITIET = new HashSet<tb_DANHSOCHITIET>();
        }
    
        public string MADS { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> TONGDS { get; set; }
        public Nullable<int> MACN { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<bool> KHOA { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
    
        public virtual tb_CHINHANH tb_CHINHANH { get; set; }
        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_DANHSOCHITIET> tb_DANHSOCHITIET { get; set; }
    }
}
