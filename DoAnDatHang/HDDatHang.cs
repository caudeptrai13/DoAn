//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnDatHang
{
    using System;
    using System.Collections.Generic;
    
    public partial class HDDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDDatHang()
        {
            this.MonAn_HDDatHang = new HashSet<MonAn_HDDatHang>();
            this.NuocUong_HDDatHang = new HashSet<NuocUong_HDDatHang>();
        }
    
        public int MaHDDatHang { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVien { get; set; }
        public System.DateTime ThoiGian { get; set; }
        public decimal ThanhTien { get; set; }
        public bool TrangThai { get; set; }
    
        public virtual Khach Khach { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn_HDDatHang> MonAn_HDDatHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NuocUong_HDDatHang> NuocUong_HDDatHang { get; set; }
    }
}