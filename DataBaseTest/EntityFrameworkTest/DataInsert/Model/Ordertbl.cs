//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 템플릿에서 생성되었습니다.
//
//     이 파일을 수동으로 변경하면 응용 프로그램에서 예기치 않은 동작이 발생할 수 있습니다.
//     이 파일을 수동으로 변경하면 코드가 다시 생성될 때 변경 내용을 덮어씁니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataInsert.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordertbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordertbl()
        {
            this.OrderDetailtbl = new HashSet<OrderDetailtbl>();
        }
    
        public string OrderCode { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string CustomerNum { get; set; }
        public int TblNum { get; set; }
        public int OrderPrice { get; set; }
        public bool OrderComplete { get; set; }
        public string OrderRemark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailtbl> OrderDetailtbl { get; set; }
    }
}
