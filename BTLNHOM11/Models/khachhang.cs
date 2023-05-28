using System.ComponentModel.DataAnnotations;

namespace BTLNHOM11.Models;
public class khachhang
{
    [Key]
    [Display(Name = "Mã Khách hàng")]
    public string makh {get; set;}

    [Display(Name = "Tên Khách hàng")]
    public string tenkh {get; set;}

    [Display(Name = "Địa chỉ")]
    public string diachikh {get; set;}

    [Display(Name = "Số điện thoại")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    public string sdtkh {get; set;}
}