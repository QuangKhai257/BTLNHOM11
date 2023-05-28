using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNHOM11.Models;
public class hoadon
{
    [Key]
    [Display(Name = "Mã hóa đơn")]
    public string mahd {get; set;}

    [Display(Name = "Tên khách hàng")]
    public string tenkh {get; set;}
    [ForeignKey("tenkh")]
    public khachhang? khachhang {get; set;}

    [Display(Name = "Tên sản phẩm")]
    public string tensp {get; set;}
    [ForeignKey("tensp")]
    public sanpham? sanpham {get; set;}

    [Display(Name = "Số lượng")]
    public string soluongban {get; set;}

     [Display(Name = "Thời gian bán ")]
    public DateTime tgban {get; set;}
}